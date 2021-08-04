using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using Ecommerce.Domain;
using System.Linq;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.Helper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.User;
using EcommerceCommon.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Http;
using EcommerceCommon.Utilities.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace Ecommerce.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession _session => httpContextAccessor.HttpContext.Session;

        public UserRepository(ApplicationDbContext dbContext, 
            IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        #region Admin
        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var user = DbContext.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return null if no user found with token
            if (user == null) return null;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return null if token is no longer active
            if (!refreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);
            DbContext.Users.Update(user);
            DbContext.SaveChanges();

            // generate new jwt
            var jwtToken = generateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            var user = DbContext.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive) return false;

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            DbContext.Users.Update(user);
            DbContext.SaveChanges();

            return true;
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }


        /// <summary>
        /// Register
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<User> Register(UserRegisterDto dto)
        {
            if (DbContext.Users.Any(x => x.Username == dto.Username))
            {
                return null;
            }

            byte[] passwordHash;
            byte[] passwordSalt;

            AuthenUserHelper.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);

            var role = DbContext.Roles.SingleOrDefault(x => x.Name == "Admin").Id;

            var user = new User()
            {
                Username = dto.Username,
                Address = dto.Address,
                //Avatar = dto.Avatar,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedBy = _session.GetString(SystemConstant.AppSettings.Username),
                RoleId = role
            };

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (DbContext.Users.Any(x => x.Username == user.Username))
                throw new Exception("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash;
            byte[] passwordSalt;

            AuthenUserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            DbContext.Users.Add(user);
            DbContext.SaveChanges();

            return user;
        }

        public async Task<int> Edit(Guid id, UserUpdateDto dto)
        {
            var user = DbContext.Users.Find(id);
            if (user == null)
            {
                throw new Exception("Không tìm thấy người dùng");
            }

            if (dto.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (DbContext.Users.Any(x => x.Username == dto.Username))
                    throw new Exception("Username " + dto.Username + " is already taken");
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                throw new Exception("Mật khẩu phải khớp nhau");
            }

            // update user properties
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Username = dto.Username;
            user.Phone = dto.Phone;
            user.Email = dto.Email;
            user.Address = dto.Address;
            user.UpdatedBy = httpContextAccessor.HttpContext.Session.GetString("Username");
            user.UpdatedDate = DateTime.Now;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                byte[] passwordHash, passwordSalt;
                AuthenUserHelper.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            DbContext.Users.Update(user);
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            var user = DbContext.Users.Find(id);
            if (user != null)
            {
                DbContext.Users.Remove(user);
                DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get user register
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewUserRegisterViewModel>> GetUserRegister()
        {
            var startDateTime = DateTime.Today;
            var endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

            var users = await DbContext.Users.Where(x => x.CreatedDate >= startDateTime && x.CreatedDate <= endDateTime)
                .Select(x => new NewUserRegisterViewModel()
                {
                    Username = x.Username,
                    Address = x.Address,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone
                }).ToListAsync();


            return users;
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserViewModel>> GetAllUser()
        {
            var users = await DbContext.Users.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Username = x.Username,
                Address = x.Address,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                IsDelete = x.IsDeleted
            }).ToListAsync();


            return users;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserViewModel> GetUserById(Guid id)
        {
            var user = await DbContext.Users.FindAsync(id);


            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                Phone = user.Phone,
                Address = user.Address,
                Avatar = user.Avatar,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = user.CreatedDate
            };

            return userViewModel;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public async Task<User> ChangePassword(ChangePassword change)
        {
            //var username = httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Username);

            return await DbContext.Users.SingleOrDefaultAsync(x => x.Username == "admin" || x.Username == "batinh");
        }

        /// <summary>
        /// Change status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ChangeStatus(Guid id)
        {
            var user = await DbContext.Users.FindAsync(id);

            user.IsDeleted = !user.IsDeleted;
            await DbContext.SaveChangesAsync();
            return user.IsDeleted;
        }
        #endregion

        #region Home page

        #endregion
    }
}

using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain;
using System.Linq;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.Helper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.User;
using EcommerceCommon.Infrastructure.Dto.User;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IConfiguration configuration;

        //private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            this.configuration = configuration;
            //_appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate2(AuthenticateRequest model)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(x => x.Username == model.Username);

            if (user == null)
            {
                throw new Exception("Username incorrect");
            }

            //byte[] passwordHash;
            //byte[] passwordSalt;
            var result = AuthenUserHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt);

            if (!result)
            {
                throw new Exception("Username or password incorrect");
            }

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            var authenticate = new AuthenticateResponse(user, token);

            return authenticate;
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
                throw new Exception("Username \"" + dto.Username + "\" is already taken");
            }

            byte[] passwordHash;
            byte[] passwordSalt;

            AuthenUserHelper.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);

            var user = new User()
            {
                Username = dto.Username,
                Address = dto.Address,
                Avatar = dto.Avatar,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user;
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("035131513513ACNMCM");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    //new Claim("id", user.Id.ToString()) 
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = DbContext.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!AuthenUserHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
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

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userParam"></param>
        /// <param name="password"></param>
        public void Update(User userParam, string password = null)
        {
            var user = DbContext.Users.Find(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (DbContext.Users.Any(x => x.Username == userParam.Username))
                    throw new Exception("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                AuthenUserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            DbContext.Users.Update(user);
            DbContext.SaveChanges();
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
                Phone = x.Phone
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
    }
}

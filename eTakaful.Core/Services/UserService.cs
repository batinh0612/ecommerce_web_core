using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Infrastructure.Helper;
using EcommerceCommon.Infrastructure.ViewModel.User;
using EcommerceCommon.Utilities.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Service.Services
{
    public class UserService : EcommerceServices<User>, IUserService
    {
        private readonly IUserRepository _userReponsitory;
        private readonly IMapper _mapper;
        private readonly Tokens _tokens;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userReponsitory, 
            IMapper mapper, 
            Tokens tokens,
            IRoleRepository roleRepository) : base(userReponsitory)
        {
            _userReponsitory = userReponsitory;
            _mapper = mapper;
            _tokens = tokens;
            _roleRepository = roleRepository;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userReponsitory.FindAsync(x => x.Username == request.Username);
            if (user == null)
                return null;

            if (user.IsDeleted == true)
            {
                 return "Tài khoản đang bị khóa";
            }

            var result = AuthenUserHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!result)
            {
                return null;
            }

            var roles = await _roleRepository.GetAllRolesString();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("Username", user.Username),
                new Claim(ClaimTypes.Name, (user.FirstName + " " + user.LastName)),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(";", roles))
            };

            var token = new JwtSecurityToken(
                _tokens.Issuer,
                _tokens.Issuer,
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokens.Key)),
                SecurityAlgorithms.HmacSha256)
                );

            var resultToken = new JwtSecurityTokenHandler().WriteToken(token);
            return resultToken;
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            return _userReponsitory.RefreshToken(token, ipAddress);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            return _userReponsitory.RevokeToken(token, ipAddress);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public async Task<User> ChangePassword(ChangePassword change)
        {
            var user = await _userReponsitory.ChangePassword(change);

            if (change.Password.Equals(change.ConfirmPassword))
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                AuthenUserHelper.CreatePasswordHash(change.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _userReponsitory.UpdateAsync(user);
                return user;
            }
            return null;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Create(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            return _userReponsitory.Create(user, password);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> Edit(Guid id, UserUpdateDto dto)
        {
            return await _userReponsitory.Edit(id, dto);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            _userReponsitory.Delete(id);
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserViewModel>> GetAllUser()
        {
            return await _userReponsitory.GetAllUser();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserViewModel> GetUserById(Guid id)
        {
            return await _userReponsitory.GetUserById(id);
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<User> Register(UserRegisterDto dto)
        {
            return await _userReponsitory.Register(dto);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        //public void Update(UserDto userDto, string password = null)
        //{
        //    var user = _mapper.Map<User>(userDto);
        //    _userReponsitory.Update(user, password);
        //}


        /// <summary>
        /// Change statuss
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ChangeStatus(Guid id)
        {
            return await _userReponsitory.ChangeStatus(id);
        }
    }
}

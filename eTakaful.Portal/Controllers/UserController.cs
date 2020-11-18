﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Portal.Infrastructure.Helper;
using Ecommerce.Portal.Infrastructure.Wrappers;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Portal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly AuthencationSetting _authencationSetting;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IOptions<AuthencationSetting> authencationSetting, IMapper mapper)
        {
            _userService = userService;
            _authencationSetting = authencationSetting.Value;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ApiResponse Login([FromBody]UserLoginDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return new ApiResponse("Username or password is incorrect", 400);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authencationSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return new ApiResponse("Login success", new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ApiResponse Register([FromBody]UserDto userDto)
        {
            try
            {
                // save 
                _userService.Create(userDto, userDto.Password);
                return new ApiResponse("Register user success", 200);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return new ApiResponse("Can't register user", ex, 400);
            }
        }
        [Authorize(Roles = "Admin")]
        [Route("get-all-user")]
        [HttpGet]
        public async Task<ApiResponse> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return new ApiResponse("list user", userDtos, 200);
        }

        
        [HttpGet("get-user-by-id/{name}")]
        public async Task<ApiResponse> GetUserByUserName(string name)
        {
            try
            {
                var user = await _userService.FindAsync(c => c.Username == name);
                if (user == null)
                {
                    return new ApiResponse("Can't find user with name", name, 200);
                }

                // var currentUserId = Guid.Parse(User.Identity.Name);
                if (!User.IsInRole("Admin"))
                {
                    return new ApiResponse("forbidden", name, 403);
                }

                var userDto = _mapper.Map<UserDto>(user);
                return new ApiResponse("user detail", userDto, 200);
            }
            catch (Exception ex)
            {
                return new ApiResponse("Can't get user infomation", ex, 400);
            }
        }

        [HttpPut("{id}")]
        public ApiResponse UpdateUser(int id, [FromBody]UserDto userDto)
        {
            try
            {
                // save 
                _userService.Update(userDto, userDto.Password);
                return new ApiResponse("Update user success", userDto, 200);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return new ApiResponse("Can't update user", ex, 400);
            }
        }

        [HttpDelete("delete-user/{id}")]
        public ApiResponse DeleteUser(Guid id)
        {
            _userService.Delete(id);
            return new ApiResponse("Delete user success", id, 200);
        }

    }
}
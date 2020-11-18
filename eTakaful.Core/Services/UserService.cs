using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.User;

namespace Ecommerce.Service.Services
{
    public class UserService : EcommerceServices<User>, IUserService
    {
        private readonly IUserRepository _userReponsitory;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userReponsitory, IMapper mapper) : base(userReponsitory)
        {
            _userReponsitory = userReponsitory;
            _mapper = mapper;
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            return _userReponsitory.Authenticate(username, password);
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
        /// Update
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        public void Update(UserDto userDto, string password = null)
        {
            var user = _mapper.Map<User>(userDto);
            _userReponsitory.Update(user,password);
        }
    }
}

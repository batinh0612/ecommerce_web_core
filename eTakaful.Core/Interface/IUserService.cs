using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Infrastructure.ViewModel.User;

namespace Ecommerce.Service.Interface
{
    public interface IUserService : IServices<User>
    {
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> Authenticate(LoginRequest request);

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<User> Register(UserRegisterDto dto);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> Edit(Guid id, UserUpdateDto dto);

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        Task<User> ChangePassword(ChangePassword change);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Create(UserDto user, string password);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        //void Update(UserDto user, string password = null);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        Task<List<UserViewModel>> GetAllUser();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserViewModel> GetUserById(Guid id);

        /// <summary>
        /// Change status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ChangeStatus(Guid id);
    }
}

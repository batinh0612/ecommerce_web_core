using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.User;

namespace Ecommerce.Repository.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<User> Register(UserRegisterDto dto);

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
        User Create(User user, string password);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> Edit(Guid id, UserUpdateDto dto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        //void Update(User user, string password = null);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);

        /// <summary>
        /// Get user register
        /// </summary>
        /// <returns></returns>
        Task<List<NewUserRegisterViewModel>> GetUserRegister();

        /// <summary>
        /// Get all users
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

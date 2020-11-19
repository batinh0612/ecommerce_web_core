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
        /// Authenticate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AuthenticateResponse> Authenticate2(AuthenticateRequest model);

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Authenticate(string username, string password);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Create(User user, string password);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        void Update(User user, string password = null);

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
    } 
}

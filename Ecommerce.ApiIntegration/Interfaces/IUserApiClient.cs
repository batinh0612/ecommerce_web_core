using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.User;
using System;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface IUserApiClient
    {
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //Task<ApiResponseNew<AuthenticateResponse>> Authenticate(AuthenticateRequest model);

        Task<ApiResponse> Authenticate(LoginRequest request);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Create(UserRegisterDto dto);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Edit(Guid id, UserUpdateDto dto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> Delete(Guid id);

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        Task<ApiResponse> ChangePassword(ChangePassword change);

        /// <summary>
        /// Change status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> ChangeStatus(Guid id);
    }
}

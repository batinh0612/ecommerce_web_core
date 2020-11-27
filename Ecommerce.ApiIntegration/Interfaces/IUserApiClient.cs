using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> Delete(Guid id);
    }
}

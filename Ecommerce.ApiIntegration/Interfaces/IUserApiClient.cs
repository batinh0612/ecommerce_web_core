using Ecommerce.WebAPI.Infrastructure.Wrappers;
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
        Task<ApiResponse> Authenticate(AuthenticateRequest model);
    }
}

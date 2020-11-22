using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.User;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public async Task<string> Authenticate(AuthenticateRequest model)
        //{
        //    var json = JsonConvert.SerializeObject(model);
        //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        //    var client = httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri(configuration["BaseAddress"]);
        //    var response = await client.PostAsync("/api/Users/Authenticate", httpContent);
        //    var result = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //return JsonConvert.DeserializeObject<string>(result);
        //        return result;
        //    }
        //    //return JsonConvert.DeserializeObject<string>(result);
        //    return null;
        //}

        public async Task<ApiResponseNew<AuthenticateResponse>> Authenticate(AuthenticateRequest model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(configuration["BaseAddress"]);
            var response = await client.PostAsync("/api/Users/Authenticate", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ApiOkResponse<AuthenticateResponse>>(result);
                return data;
            }
            return JsonConvert.DeserializeObject<ApiBadRequestResponse<AuthenticateResponse>>(result);
        }
    }
}

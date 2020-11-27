using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Utilities.Constants;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> Authenticate(LoginRequest request)
        {
            var url = configuration[SystemConstant.AppSettings.BaseAddress];
            var response = await url.AppendPathSegment("/api/Users/Authenticate").PostJsonAsync(request).ReceiveJson<ApiResponse>();
            return response;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Delete(Guid id)
        {
            var session = httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(configuration[SystemConstant.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var response = await client.DeleteAsync($"api/Users/delete-user/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiResponse>(body);
            }
            return JsonConvert.DeserializeObject<ApiResponse>(body);
        }
    }
}

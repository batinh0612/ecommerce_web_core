using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Utilities.Constants;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor):
            base(httpClientFactory, configuration, httpContextAccessor)
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

        public async Task<ApiResponse> Create(UserRegisterDto dto)
        {
            var data = await PostAsync<ApiResponse>("/api/Users/create-user", dto);
            if (data.Result != null)
            {
                var result = JsonConvert.DeserializeObject<User>(data.Result.ToString());
                return new ApiResponse(data.Message, result);
            }
            return new ApiResponse(data.Message);
        }

        public async Task<ApiResponse> ChangePassword(ChangePassword change)
        {
            var url = configuration[SystemConstant.AppSettings.BaseAddress];
            var token = httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var response = await url.AppendPathSegment("/api/users/change-password").WithOAuthBearerToken(token).PostJsonAsync(change).ReceiveJson<ApiResponse>();

            //var response = await PostAsync<ApiResponse>($"/api/users/change-password", change);
            if (response.Result != null)
            {
                var result = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                return new ApiResponse(response.Message, result);
            }
            return new ApiResponse(response.Message);
        }

        public async Task<ApiResponse> Edit(Guid id, UserUpdateDto dto)
        {
            return await PostAsync<ApiResponse>($"/api/users/update-user/{id}", dto);
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

        public async Task<ApiResponse> ChangeStatus(Guid id)
        {
            //return await PostAsync<ApiResponse>($"/api/users/change-status/{id}");
            var url = configuration[SystemConstant.AppSettings.BaseAddress];
            var token = httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var response = await url.AppendPathSegment($"/api/users/change-status/{id}").WithOAuthBearerToken(token).PostAsync().ReceiveJson<ApiResponse>();
            return response;
        }
    }
}

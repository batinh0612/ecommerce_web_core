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
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;//lay ra token

        protected BaseApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get async
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return myDeserializedObjList;
            }

            var result = JsonConvert.DeserializeObject<TResponse>(body);
            return result;
        }

        /// <summary>
        /// Get list async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="requiredLogin"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            var sessions = _httpContextAccessor.HttpContext.Session
               .GetString(SystemConstant.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            throw new Exception(body);
        }

        public async Task<T> PostAsync<T>(string segment, object dto)
        {
            var url = _configuration[SystemConstant.AppSettings.BaseAddress];
            var token = _httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var response = await url.AppendPathSegment(segment).WithOAuthBearerToken(token).PostJsonAsync(dto).ReceiveJson<T>();
            return response;
        }

        public async Task<T> FlurlGetAsync<T>(string segment)
        {
            var url = _configuration[SystemConstant.AppSettings.BaseAddress];
            var token = _httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            return await url.AppendPathSegment(segment).WithOAuthBearerToken(token).GetJsonAsync<T>();
        }

        public async Task<bool> Delete(string url)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstant.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstant.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}

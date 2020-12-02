using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) :
            base(httpClientFactory, configuration, httpContextAccessor)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> NewProductHomePage()
        {
            var sessions = httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(configuration[SystemConstant.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync("/api/products/get-latest-products");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ApiResponse myDeserializedObjList = JsonConvert.DeserializeObject<ApiResponse>(body);
                var apiResponse = JsonConvert.DeserializeObject<List<ProductHomePageViewModel>>(myDeserializedObjList.Result.ToString());
                return new ApiResponse(myDeserializedObjList.Message, apiResponse, myDeserializedObjList.StatusCode);
            }

            var result = JsonConvert.DeserializeObject<ApiResponse>(body);
            return result;
        }
    }
}

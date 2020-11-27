using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Supplier;
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
    public class SupplierApiClient : BaseApiClient, ISupplierApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SupplierApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Create(SupplierDto dto)
        {
            return await PostAsync<ApiResponse>("/api/Suppliers/add-supplier", dto);
        }

        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetAllSuppliers()
        {
            var data = await FlurlGetAsync<ApiResponse>("/api/Suppliers/get-all-supplier");
            var result = JsonConvert.DeserializeObject<List<Supplier>>(data.Result.ToString());
            return new ApiResponse(data.Message, result);
        }

        public async Task<ApiResponse> Update(Guid id, SupplierDto dto)
        {
            return await PostAsync<ApiResponse>($"/api/suppliers/update-supplier/{id}", dto);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetById(Guid id)
        {
            var response = await FlurlGetAsync<ApiResponse>($"/api/suppliers/{id}");
            var result = JsonConvert.DeserializeObject<Supplier>(response.Result.ToString());
            return new ApiResponse(response.Message, result);
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
            var response = await client.DeleteAsync($"/api/Suppliers/delete-supplier/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiResponse>(body);
            }
            return JsonConvert.DeserializeObject<ApiResponse>(body);
        }
    }
}

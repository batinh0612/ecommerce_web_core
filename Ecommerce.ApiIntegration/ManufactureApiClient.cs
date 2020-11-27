using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class ManufactureApiClient : BaseApiClient, IManufactureApiClient
    {
        public ManufactureApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResponse> Create(ManufactureDto dto)
        {
            return await PostAsync<ApiResponse>("/api/manufactures/add-manufacture", dto);
        }

        public async Task<ApiResponse> Update(Guid id, ManufactureDto dto)
        {
            var response = await PostAsync<ApiResponse>($"/api/manufactures/update-manufacture/{id}", dto);
            var result = JsonConvert.DeserializeObject<Manufacture>(response.Result.ToString());
            return new ApiResponse(response.Message, result);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            return await Delete($"/api/manufactures/delete-manufacture-by-id/{id}");
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetAll()
        {
            var response = await FlurlGetAsync<ApiResponse>("/api/manufactures/get-all-manufactures");
            var result = JsonConvert.DeserializeObject<List<Manufacture>>(response.Result.ToString());
            return new ApiResponse(response.Message, result);
        }

        public async Task<ApiResponse> GetById(Guid id)
        {
            var response = await FlurlGetAsync<ApiResponse>($"/api/manufactures/{id}");
            var result = JsonConvert.DeserializeObject<Manufacture>(response.Result.ToString());
            return new ApiResponse(response.Message, result);
        }
    }
}

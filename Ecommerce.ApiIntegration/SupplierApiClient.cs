using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
//using Ecommerce.WebAPI.Infrastructure.ApiResponse;
//using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class SupplierApiClient : BaseApiClient, ISupplierApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SupplierApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        public async Task<Supplier> Create(SupplierDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5003");
            var response = await client.PostAsync($"/api/Suppliers/add-supplier", httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Supplier>(result);
            }

            return JsonConvert.DeserializeObject<Supplier>(result);
        }

        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <returns></returns>
        public async Task<List<Supplier>> GetAllSuppliers()
        {

            ////var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            //var client = httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(configuration["BaseAddress"]);
            ////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            //var response = await client.GetAsync("/api/Suppliers/get-all-supplier");
            //var body = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //{
            //    var myDeserializedObjList = (List<Supplier>)JsonConvert.DeserializeObject(body);
            //    return myDeserializedObjList;
            //}

            //throw new ApiException("Errors");

            var data = await GetListAsync<Supplier>("/api/Suppliers/get-all-supplier");
            return data;

            //var result = JsonConvert.DeserializeObject<ApiResponse>(body);
            //return result;
            //return await GetAsync<List<Supplier>>("/api/Suppliers/GetAll");

            //return await GetListAsync<Supplier>("/api/Suppliers/GetAll");
        }
    }
}

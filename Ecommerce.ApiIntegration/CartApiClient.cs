using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Cart;
using EcommerceCommon.Infrastructure.ViewModel.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class CartApiClient : BaseApiClient, ICartApiClient
    {
        public CartApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {

        }

        public async Task<ApiResponse> GetAllCart()
        {
            var data = await FlurlGetAsync<ApiResponse>("/api/carts/get-all-cart");
            var result = JsonConvert.DeserializeObject<List<CartDetailViewModel>>(data.Result.ToString());
            return new ApiResponse(data.Message, result);
        }

        public async Task<ApiResponse> AddCart(CartDto cartDto)
        {
            var response = await PostAsync<ApiResponse>("/api/carts/add-cart", cartDto);
            return response;
        }
    }
}

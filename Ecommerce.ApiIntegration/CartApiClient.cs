using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration
{
    public class CartApiClient : BaseApiClient, ICartApiClient
    {
        protected CartApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {

        }

        public async Task<ApiResponse> AddCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, int Quantity, Guid UserId, string LanguageId)
        {
            //var response = await PostAsync<ApiResponse>("/api/add-cart");
            throw new NotImplementedException();
        }
    }
}

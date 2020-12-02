using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductSevice _productSevice;

        public ProductsController(IProductSevice productSevice)
        {
            _productSevice = productSevice;
        }

        [HttpGet("get-latest-products")]
        public async Task<ApiResponse> LatestProducts()
        {
            try
            {
                var result = await _productSevice.NewProductHomePage();

                var api = new ApiResponse("List new product", result, 200);
                return api;
            }
            catch (Exception ex)
            {

                throw new ApiException(ex);
            }
        }
    }
}

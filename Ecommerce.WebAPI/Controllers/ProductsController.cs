using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Utilities.Constants;
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

        [HttpGet]
        [Route("get-latest-products")]
        public async Task<ApiResponse> LatestProducts()
        {
            var result = await _productSevice.NewProductHomePage();

            return new ApiResponse("List new product", result, 200);
        }


        [HttpGet("get-featured-products/{take}")]
        public async Task<ApiResponse> FeaturedProducts(int take)
        {
            try
            {
                var result = await _productSevice.FeaturedProductHomePage(take);

                var api = new ApiResponse("List featured product", result, 200);
                return api;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex);
            }
        }


        [HttpGet("{id}")]
        public async Task<ApiResponse> ProductDetails(Guid id)
        {
            try
            {
                var languageId = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
                var product = await _productSevice.GetProductById(id, languageId);
                var api = new ApiResponse("Product details", product, 200);
                return api;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex);
            }
        }
    }
}

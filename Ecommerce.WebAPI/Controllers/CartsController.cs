using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
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
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("add-cart")]
        public async Task<ApiResponse> AddCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, int Quantity, Guid UserId, string LanguageId)
        {
            var result = await cartService.AddCart(ProductId, ProductSizeId, ProductColorId, Quantity, UserId, LanguageId);
            if (result == true)
            {
                return new ApiResponse("Add cart succcesful", result, 200);
            }
            return new ApiResponse("Fail");
        }
    }
}

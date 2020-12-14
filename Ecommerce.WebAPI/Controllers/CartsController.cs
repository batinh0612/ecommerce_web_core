using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Cart;
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
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("get-all-cart")]
        [Authorize]
        public async Task<ApiResponse> GetAllCart(Guid UserId)
        {
            var result = await cartService.GetAllProductCart(UserId);
            return new ApiResponse("List cart", result);

        }

        [HttpPost("add-cart")]
        [Authorize]
        public async Task<ApiResponse> AddCart(CartDto cartDto)
        {
            var result = await cartService.AddCart(cartDto.ProductId, cartDto.ProductSizeId, 
                cartDto.ProductColorId, cartDto.Quantity, cartDto.UserId, cartDto.LanguageId);
            if (result == true)
            {
                return new ApiResponse("Add cart succcesful", result, 200);
            }
            return new ApiResponse("Fail");
        }
    }
}

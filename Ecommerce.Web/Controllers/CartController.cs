using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ICartApiClient cartApiClient;
        private readonly ICartDetailRepository cartDetailRepository;

        public CartController(ICartService cartService, ICartApiClient cartApiClient, ICartDetailRepository cartDetailRepository)
        {
            this.cartService = cartService;
            this.cartApiClient = cartApiClient;
            this.cartDetailRepository = cartDetailRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var result = await cartService.GetAllProductCart(Guid.Parse(userId));
            //var result = await cartApiClient.GetAllCart();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(CartDto cartDto)
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            cartDto.LanguageId = "vi";
            //var result = await cartApiClient.AddCart(cartDto);
            var result = await cartService.AddCart(cartDto.ProductId, cartDto.ProductSizeId, cartDto.ProductColorId, cartDto.Quantity,
                cartDto.UserId, cartDto.LanguageId);
            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Detail", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            await cartService.DeleteCart(id);
            return Ok();
        }
    }
}

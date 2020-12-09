using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await cartService.GetAllProductCart();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, int Quantity, Guid UserId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            UserId = Guid.Parse("4f8a41cb-6d93-46f8-8405-6e5ddc49be87");
            var result = await cartService.AddCart(ProductId, ProductSizeId, ProductColorId, Quantity, UserId, "vi");
            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Detail", "Product");
        }
    }
}

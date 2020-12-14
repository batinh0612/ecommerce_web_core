using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers
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
            //var userId = HttpContext.Session.GetString("UserId");
            //var result = await cartService.GetAllProductCart(Guid.Parse(userId));
            var result = await cartService.GetListCart();
            return View(result);
        }

        public async Task<IActionResult> CartDetail(Guid id)
        {
            var cartDetails = await cartService.GetListCartDetailViewModelById(id);
            return View(cartDetails);
        }
    }
}

using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ICartApiClient cartApiClient;
        private readonly ICartDetailRepository cartDetailRepository;
        private readonly IProductSevice productSevice;

        public CartController(ICartService cartService, 
            ICartApiClient cartApiClient, 
            ICartDetailRepository cartDetailRepository,
            IProductSevice productSevice)
        {
            this.cartService = cartService;
            this.cartApiClient = cartApiClient;
            this.cartDetailRepository = cartDetailRepository;
            this.productSevice = productSevice;
        }
        [HttpGet]
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
        [HttpGet]
        public async Task<IActionResult> GetListItems()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var result = await cartService.GetAllProductCart(Guid.Parse(userId));

            return Ok(result);
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
            var res = await cartService.DeleteCart(id);
            return Ok(res);
        }

        public async Task<IActionResult> UpdateCart(Guid id, int quantity)
        {
            var cartbyId = cartDetailRepository.GetById(id);
            var product = await productSevice.GetByIdAsync(cartbyId.ProductId.Value);
            var cart = cartService.Find(x => x.Id == cartbyId.CartId);
            var cartDetail = cartDetailRepository.GetAll().Where(x => x.CartId == cartbyId.CartId).ToList();

            foreach (var item in cartDetail)
            {
                if (item.Id == id)
                {
                    if (quantity == 0)
                    {
                        await cartDetailRepository.DeleteAsync(item);
                        break;
                    }

                    if (quantity > item.Quantity)
                    {
                        var discountPrice = item.Price - ((product.PercentDiscount * item.Price) / 100);
                        cart.TotalPrice += discountPrice.Value * (quantity - item.Quantity);
                        cart.FeeMount += ((product.PercentDiscount.Value * product.Price) / 100) * (quantity - item.Quantity);
                        item.Quantity = quantity;
                        await cartDetailRepository.UpdateAsync(item);
                        await cartService.UpdateAsync(cart);
                    }else if(quantity < item.Quantity)
                    {
                        var discountPrice = item.Price - ((product.PercentDiscount * item.Price) / 100);
                        cart.TotalPrice -= discountPrice.Value * (item.Quantity - quantity);
                        cart.FeeMount -= ((product.PercentDiscount.Value * product.Price) / 100) * (item.Quantity - quantity);
                        item.Quantity = quantity;
                        await cartDetailRepository.UpdateAsync(item);
                        await cartService.UpdateAsync(cart);
                    } 
                }
            }
            return Ok(cartDetail);
        }
    }
}

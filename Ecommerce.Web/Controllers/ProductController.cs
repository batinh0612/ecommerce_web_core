using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Web.Models;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IProductSevice productSevice;

        public ProductController(IProductApiClient productApiClient, IProductSevice productSevice)
        {
            _productApiClient = productApiClient;
            this.productSevice = productSevice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            //var response = await _productApiClient.GetById(id);
            //return View(response.Result);
            var colors = await productSevice.ListItemProductColor();
            ViewBag.ListColors = colors.Select(x => new SelectListItem() { 
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var sizes = await productSevice.ListItemProductSize();
            ViewBag.ListSizes = sizes.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var languageId = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
            var details = new ProductDetailViewModel
            {
                Details = await productSevice.GetProductById(id, "vi"),
                ListColors = await productSevice.ListItemProductColor()
            };
            return View(details);
        }
    }
}

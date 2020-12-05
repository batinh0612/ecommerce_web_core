using Ecommerce.ApiIntegration.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var response = await _productApiClient.GetById(id);
            return View(response.Result);
        }
    }
}

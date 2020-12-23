using EcommerceCommon.Infrastructure.ViewModel.ProductSize;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers
{
    public class ProductSizeController : Controller
    {
        public ProductSizeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<List<ProductSizeViewModel>> GetAllSize()
        {
            throw new NotImplementedException();
        }
    }
}

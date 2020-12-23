using EcommerceCommon.Infrastructure.ViewModel.ProductColor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers
{
    public class ProductColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<List<ProductColorViewModel>> GetAllColor()
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Web.Models;
using AutoMapper;
using Ecommerce.ApiIntegration.Interfaces;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using Ecommerce.Service.Interface;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductApiClient _productApiClient;
        private readonly IProductSevice productSevice;

        public HomeController(IMapper mapper, IProductApiClient productApiClient, IProductSevice  productSevice)
        {
            _mapper = mapper;
            _productApiClient = productApiClient;
            this.productSevice = productSevice;
        }

        public async Task<IActionResult> Index()
        {
            var newProduct = await _productApiClient.NewProductHomePage();
            //var newP = await productSevice.NewProductHomePage();
            var homePage = new HomePageViewModel
            {
                LatestProducts = (List<ProductHomePageViewModel>)newProduct.Result
                //LatestProducts = newP
            };
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

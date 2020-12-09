using System.Threading.Tasks;
using Ecommerce.Admin.Models;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _dashboardService;
        private readonly IConfiguration _configuration;

        public DashboardController(IDashboardService dashboardService, IConfiguration configuration)
        {
            _dashboardService = dashboardService;
            _configuration = configuration;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var languageId = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
            var models = new DashboardViewModel
            {
                TotalOrder = await _dashboardService.GetTotalOrder(),
                NewUserRegisters = await _dashboardService.GetUserRegisters(),
                NewProduct = await _dashboardService.GetNewProduct(languageId),
                MostViewProducts = await _dashboardService.GetProductView(languageId),
                NewOrders = await _dashboardService.GetNewOrder()
            };
            return View(models);
        }

        /// <summary>
        /// New order
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ListNewOrder()
        {
            var newOrder = await _dashboardService.GetNewOrder();
            return View(newOrder);
        }

        /// <summary>
        /// New product
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> NewProduct()
        {
            var languageId = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
            var newProduct = await _dashboardService.GetNewProduct(languageId);
            return View(newProduct);
        }

        /// <summary>
        /// New user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> NewUser()
        {
            var users = await _dashboardService.GetUserRegisters();
            return View(users);
        }

        [HttpPost]
        public IActionResult Language(NavigationViewModel viewModel)
        {
            HttpContext.Session.SetString(SystemConstant.DefaultLanguageId, viewModel.CurrentLanguageId);

            return Redirect(viewModel.ReturnUrl);
        }
    }
}

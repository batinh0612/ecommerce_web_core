using Ecommerce.ApiIntegration.Interfaces;
using EcommerceCommon.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserApiClient userApiClient;
        private readonly IConfiguration configuration;

        public LoginController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            this.userApiClient = userApiClient;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await userApiClient.Authenticate(model);

            if (result.Result == null)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

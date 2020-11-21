using Ecommerce.ApiIntegration.Interfaces;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

            var token = await userApiClient.Authenticate(model);

            if (token == null)
            {
                ModelState.AddModelError("", "Token...");
                return View();
            }

            var userPrincipal = this.ValidateToken(token);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };

            HttpContext.Session.SetString(SystemConstant.AppSettings.Token, token);


            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    authProperties
                );

            TempData["Username"] = model.Username;

            return RedirectToAction("Index", "Dashboard");
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validateToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validateToken);

            return principal;
        }
    }
}

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

namespace Ecommerce.Web.Controllers
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

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString(SystemConstant.AppSettings.Token) != null)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Session.Remove(SystemConstant.AppSettings.Token);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await userApiClient.Authenticate(request);

            if (result.Result == null)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }

            var userPrincipal = this.ValidateToken(result.Result.ToString());
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };

            HttpContext.Session.SetString(SystemConstant.AppSettings.DefaultLanguageId, configuration["DefaultLanguageId"]);
            HttpContext.Session.SetString(SystemConstant.AppSettings.Token, result.Result.ToString());

            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    authProperties
                );

            var cl = HttpContext.User.Claims.ToList();

            //var claims = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            //var currentUser = HttpContext.User;

            //if (currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            //{
            //    var userId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //}
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //IEnumerable<Claim> claim = identity.Claims;
            //var userId = claim.Where(x => x.Type == "Username").FirstOrDefault().Value;

            //HttpContext.Session.SetString("UserId", userId);
            HttpContext.Session.SetString(SystemConstant.AppSettings.Username, request.Username);
            return RedirectToAction("Index", "Home");
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

using Ecommerce.Admin.Models;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Interface;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageService _languageService;

        public NavigationViewComponent(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageService.GetAllAsync();

            var navigation = new NavigationViewModel()
            {
                CurrentLanguageId = HttpContext.Session.GetString(SystemConstant.DefaultLanguageId),
                Languages = languages
            };

            return View("Default", navigation);
        }
    }
}

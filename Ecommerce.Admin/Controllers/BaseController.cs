using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString(SystemConstant.AppSettings.Token);
            if (session == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.WebAPI.Infrastructure.Filter
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        //public override void OnException(HttpActionExecutedContext context)
        //{

        //}

        public override void OnException(ExceptionContext context)
        {
        }
    }
}

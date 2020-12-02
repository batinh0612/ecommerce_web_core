using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

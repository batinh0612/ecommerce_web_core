using System.Threading.Tasks;
using Ecommerce.ApiIntegration.Interfaces;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierApiClient supplierApiClient;

        public SupplierController(ISupplierApiClient supplierApiClient)
        {
            this.supplierApiClient = supplierApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await supplierApiClient.GetAllSuppliers();

            if (suppliers != null)
            {
                return View(suppliers);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await supplierApiClient.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}

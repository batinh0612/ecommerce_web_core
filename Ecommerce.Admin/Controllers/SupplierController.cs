using System;
using System.Threading.Tasks;
using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Controllers
{
    public class SupplierController : BaseController
    {
        private readonly ISupplierApiClient supplierApiClient;

        public SupplierController(ISupplierApiClient supplierApiClient)
        {
            this.supplierApiClient = supplierApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await supplierApiClient.GetAllSuppliers();

            if (suppliers.Result != null)
            {
                ViewBag.Success = TempData["result"];
                return View(suppliers.Result);
            }

            return RedirectToAction("Index", "Dashboard");
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

            if (result.Result != null)
            {
                TempData["result"] = "Thêm nhà cung cấp thành công";
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplier = await supplierApiClient.GetById(id);
            return View(supplier.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, SupplierDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await supplierApiClient.Update(id, dto);

            if (result.IsError)
                return View(dto);

            TempData["result"] = "Cập nhật nhà cung cấp thành công";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var supplier = await supplierApiClient.GetById(id);
            return View(supplier.Result);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var result = await supplierApiClient.Delete(id);

            return Json(new { 
                status = !result.IsError
            });
        } 
    }
}

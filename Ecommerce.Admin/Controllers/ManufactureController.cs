using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManufactureController : BaseController
    {
        private readonly IManufactureApiClient manufactureApiClient;
        private ApplicationDbContext _context;

        public ManufactureController(IManufactureApiClient manufactureApiClient, ApplicationDbContext context)
        {
            this.manufactureApiClient = manufactureApiClient;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = await manufactureApiClient.GetAll();

            //var listManufactures = JsonConvert.DeserializeObject<List<Manufacture>>(result.Result.ToString());

            if (!result.IsError && result.Result != null)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.Success = TempData["result"];
                }
                
                return View(result.Result);
            }
            return RedirectToAction("Index", "Dashboard");
        }
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManufactureDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await manufactureApiClient.Create(dto);

            if (result != null)
            {
                TempData["result"] = "Thêm nhà sản xuất thành công";
                return RedirectToAction("Index");
            }

            return View(dto);
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var manufacture = await manufactureApiClient.GetById(id);
            return View(manufacture.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ManufactureDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await manufactureApiClient.Update(id, dto);

            if (result.IsError)
                return View(dto);

            TempData["result"] = "Cập nhật nhà sản xuất thành công";

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Delete(Guid id)
        {
            var result = await manufactureApiClient.Delete(id);
            return Json(new { 
                status = result
            });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var manufacture = await manufactureApiClient.GetById(id);
            return View(manufacture.Result);
        }
    }
}

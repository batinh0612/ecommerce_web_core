using System;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.Product;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductSevice _productSevice;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IManufactureService _manufactureService;

        public ProductController(IProductSevice productSevice, 
            ICategoryService categoryService,
            ISupplierService supplierService,
            IManufactureService manufactureService)
        {
            _productSevice = productSevice;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _manufactureService = manufactureService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId)
        {
            var languageId = HttpContext.Session.GetString(SystemConstant.DefaultLanguageId);

            if (TempData["result"] != null)
            {
                ViewBag.Success = TempData["result"];
            }

            var categories = await _categoryService.GetAllCategories(languageId);

            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId == x.Id
            });

            var products = await _productSevice.GetAllProducts(languageId, categoryId);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
            var product = await _productSevice.GetProductById(id, languageId);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var suppliers = await _supplierService.GetAllSuppliers();

            ViewBag.Suppliers = suppliers.Select(x => new SelectListItem() { 
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var manufactures = await _manufactureService.GetAllManufactures();

            ViewBag.Manufactures = manufactures.Select(x => new SelectListItem() { 
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var colors = await _productSevice.ListItemProductColor();
            ViewBag.ListColors = colors.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var sizes = await _productSevice.ListItemProductSize();
            ViewBag.ListSizes = sizes.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var languageId = HttpContext.Session.GetString(SystemConstant.DefaultLanguageId);
            var categories = await _categoryService.GetAllCategories(languageId);

            ViewBag.Categories = categories.Select(x => new SelectListItem() { 
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]//cho phep nhan kieu du lieu truyen len la form-data
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var suppliers = await _supplierService.GetAllSuppliers();

                ViewBag.Suppliers = suppliers.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                var manufactures = await _manufactureService.GetAllManufactures();

                ViewBag.Manufactures = manufactures.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                var colors = await _productSevice.ListItemProductColor();
                ViewBag.ListColors = colors.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                var sizes = await _productSevice.ListItemProductSize();
                ViewBag.ListSizes = sizes.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                var languageId = HttpContext.Session.GetString(SystemConstant.DefaultLanguageId);
                var categories = await _categoryService.GetAllCategories(languageId);

                ViewBag.Categories = categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                return View(dto);
            }

            var result = await _productSevice.Create(dto);

            if (result)
            {
                TempData["result"] = "Thêm sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstant.AppSettings.DefaultLanguageId);
            var product = await _productSevice.GetProductById(id, languageId);

            var productUpdate = new ProductUpdateDto()
            {
                Id = product.Id,
                Description = product.Description,
                Details = product.Details,
                Keyword = product.Keyword,
                Name = product.Name,
                ProductStatus = product.ProductStatus,
                SeoAlias = product.SeoAlias,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle,
                ShortDescription = product.ShortDescription,
                ImageLink = product.ImageLink
            };

            return View(productUpdate);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _productSevice.Update(dto);

            if (result == 1 || result == 2)
            {
                TempData["result"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");

            return View(dto);
        }


        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var result = await _productSevice.Delete(id);

            if (result)
            {
                return Json(new { 
                    status = result
                });
            }

            return Json(new
            {
                status = result
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.Category;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ApplicationDbContext DbContext;

        public CategoryController(ICategoryService  categoryService, ApplicationDbContext dbContext)
        {
            _categoryService = categoryService;
            DbContext = dbContext;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var languageId = HttpContext.Session.GetString(SystemConstant.DefaultLanguageId);

            var categories = _categoryService.GetListCategories(languageId);

            ViewBag.Success = TempData["result"];

            return View(categories);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var catgory = await _categoryService.GetCategoryById(id);
            return View(catgory);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategories();

            ViewBag.Categories = categories.Select(x => new SelectListItem() { 
                Text = x.Name,
                Value = x.Id.ToString()
            });


            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategories();

                ViewBag.Categories = categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                return View();
            }

            var result = await _categoryService.Create(dto);

            if (result)
            {
                TempData["result"] = "Thêm danh mục thành công";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm danh mục thất bại");

            

            return View(result);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _categoryService.GetCategoryById(id);

            if (result != null)
            {
                var category = new CategoryUpdateDto()
                {
                    CommonStatus = result.CommonStatus,
                    Description = result.Description,
                    Id = result.Id,
                    MetaTitle = result.MetaTitle,
                    Name = result.Name,
                    ParentId = result.ParentId
                };

                return View(category);
            }

            return RedirectToAction("Error", "Home");
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _categoryService.Update(dto);

            if (result == 2)
            {
                TempData["result"] = "Cập nhật danh mục thành công";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật danh mục thất bại");

            return View(result);
        }

        //[HttpGet]
        //public JsonResult LoadData()
        //{
        //    IQueryable<Category> model = DbContext.Categories.Where(x => x.IsDeleted == false);

        //    return Json(new
        //    {
        //        data = model,
        //        status = true
        //    });
        //}

        /// <summary>
        /// Change status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ChangeStatus(Guid id)
        {
            var result = await _categoryService.ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var result = await _categoryService.Delete(id);

            if (result)
            {
                return Json(new
                {
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

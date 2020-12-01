using System;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserApiClient userApiClient;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IUserApiClient userApiClient, IMapper mapper)
        {
            _userService = userService;
            this.userApiClient = userApiClient;
            this.mapper = mapper;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.Success = TempData["result"];
            }
            var users = await _userService.GetAllUser();
            return View(users);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userService.GetUserById(id);

            return View(user);
        }
        
        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var response = await userApiClient.Create(dto);
            if (response.Result == null)
            {
                
                ViewBag.Result = response.Message;
                return View(dto);
            }
            TempData["result"] = response.Message;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            var result = await userApiClient.Delete(id);

            return Json(new
            {
                status = !result.IsError
            });
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword change)
        {
            var result = await userApiClient.ChangePassword(change);
            if (result.Result != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ModelState.AddModelError("", result.Message);
            return View(change);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var user = _userService.GetById(id);
            var userUpdate = mapper.Map<UserUpdateDto>(user);
            return View(userUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UserUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await userApiClient.Edit(id, dto);
            if (result.IsError == false)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var result = await userApiClient.ChangeStatus(id);
            return Json(new
            {
                status = result.Result
            });
        }
    }
}

using System;
using System.Threading.Tasks;
using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserApiClient userApiClient;

        public UserController(IUserService userService, IUserApiClient userApiClient)
        {
            _userService = userService;
            this.userApiClient = userApiClient;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
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

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}
    }
}

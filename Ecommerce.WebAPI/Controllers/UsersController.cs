using Ecommerce.Domain;
using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Extensions;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UsersController(IUserService userService, ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            this.applicationDbContext = applicationDbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("authenticate")]
        public async Task<ApiResponse> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResponse("Isvalid", ModelState);
            }

            var token = await _userService.Authenticate(request);
            if (token == "Tài khoản đang bị khóa")
            {
                return new ApiResponse("Tài khoản đang bị khóa");
            }
            if (string.IsNullOrEmpty(token))
            {
                return new ApiResponse("Sai tài khoản hoặc mật khẩu");
            }
            HttpContext.Session.SetString(SystemConstant.AppSettings.Username, request.Username);
            return new ApiResponse("Authentication", token, 200);
        }

        [HttpPost("create-user")]
        public async Task<ApiResponse> Create([FromBody]UserRegisterDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ApiResponse(ModelState.AllErrors().ToString());
                }
                if (dto.Password == dto.ConfirmPassword)
                {
                    var user = await _userService.Register(dto);
                    if (user == null)
                    {
                        return new ApiResponse("Username \"" + dto.Username + "\" is already taken");
                    }
                    return new ApiResponse("Create user successful", user, 200);
                }
                return new ApiResponse("Confirmation password must be the same");
            }
            catch (Exception ex)
            {
                throw new ApiException(ex);
            }
        }

        [HttpPost("change-password")]
        public async Task<ApiResponse> ChangePassword(ChangePassword change)
        {
            try
            {
                var user = await _userService.ChangePassword(change);
                if (user != null)
                {
                    return new ApiResponse("Change password successful", user, 200);
                }
                return new ApiResponse("Xác nhận mật khẩu phải giống nhau");
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.ToString());
            }
        }

        [HttpDelete("delete-user/{id}")]
        [Authorize]
        public async Task<ApiResponse> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return new ApiResponse($"Cannot found user with id: {id}");

            await _userService.DeleteAsync(user);
            return new ApiResponse("Delete user successful");
        }

        [HttpPost("update-user/{id}")]
        [AllowAnonymous]
        public async Task<ApiResponse> Edit(Guid id, [FromBody]UserUpdateDto dto)
        {
            var result = await _userService.Edit(id, dto);
            if (result == 1)
            {
                return new ApiResponse("Update user successful", dto, 200);
            }
            return new ApiResponse("Update user failure");
        }

        [HttpPost("Change-status/{id}")]
        public async Task<ApiResponse> ChangeStatus(Guid id)
        {
            var result = await _userService.ChangeStatus(id);
            return new ApiResponse("Success", result, 200);
        }
    }
}

using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Extensions;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Authorization;
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

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<ApiResponse> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }

            var token = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(token))
            {
                throw new ApiException("Token null");
            }

            return new ApiResponse("Authentication", token, 200);
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
    }
}

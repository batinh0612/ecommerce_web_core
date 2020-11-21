using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Helper;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AuthencationSetting _authencationSetting;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IOptions<AuthencationSetting> authencationSetting, IConfiguration configuration)
        {
            _authencationSetting = authencationSetting.Value;
            _userService = userService;
            _configuration = configuration;
        }

        //[AllowAnonymous]
        //[HttpPost("login")]
        //public ApiResponse Login([FromBody] UserLoginDto userDto)
        //{
        //    //var user = await _userService.Authenticate(userDto.Username, userDto.Password, userDto.SessionId);

        //    //if (user == null)
        //    //    throw new ApiException("Tên đăng nhập hoặc mật khẩu không chính xác", 200);

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING"));
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, "SyNV"),
        //            new Claim(ClaimTypes.Role, "admin")
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return new ApiResponse("Token", tokenString, 200);
        //}

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ApiResponse> Authenticate([FromBody]AuthenticateRequest model)
        {
            var response = await _userService.Authenticate2(model);

            if (response == null)
                throw new ApiException("Tên đăng nhập hoặc mật khẩu không chính xác", 200);

            return new ApiResponse("Token", response, 200);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ApiResponse> Register([FromBody] UserRegisterDto dto)
        {
            var user = await _userService.Register(dto);

            if (user == null)
                throw new ApiException("Register user failure", 200);

            return new ApiResponse("Register user successful", user, 200);
        }
    }
}

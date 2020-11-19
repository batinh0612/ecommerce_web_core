using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EcommerceCommon.Infrastructure.Dto.User
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        //[JsonIgnore]
        public string Password { get; set; }
    }
}

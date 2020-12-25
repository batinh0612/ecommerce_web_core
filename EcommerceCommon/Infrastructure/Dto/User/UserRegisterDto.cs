using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCommon.Infrastructure.Dto.User
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Roles { get; set; }
        //public string Avatar { get; set; }

        //[Display(Name = "Tên")]
        //public string FirstName { get; set; }

        //[Display(Name = "Họ")]
        //public string LastName { get; set; }

        //[Display(Name = "Email")]
        //public string Email { get; set; }

        //[Display(Name = "Số điện thoại")]
        //public string Phone { get; set; }

        //public string Address { get; set; }

        //[Display(Name = "Tài khoản")]
        //public string Username { get; set; }

        //public string Avatar { get; set; }

        //[Display(Name = "Mật khẩu")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Display(Name = "Xác nhận mật khẩu")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
    }
}

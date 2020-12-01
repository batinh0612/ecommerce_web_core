using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.User
{
    public class UserViewModel
    {
        [Display(Name = "Mã")]
        public Guid Id { get; set; }

        [Display(Name = "Tài khoản")]
        public string Username { get; set; }

        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        public bool IsDelete { get; set; }
    }
}

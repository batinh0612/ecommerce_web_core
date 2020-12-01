using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.User
{
    public class ChangePassword
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}

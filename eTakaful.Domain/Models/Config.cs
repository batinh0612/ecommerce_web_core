using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Config
    {
        #region Property
        [Key]
        public Guid Key { get; set; }
        public string Value { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Language
    {
        #region Property
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        #endregion
    }
}

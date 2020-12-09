using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class ProductSize : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}

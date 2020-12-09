using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class ProductAttribute : BaseModel
    {
        public Guid? ProductSizeId { get; set; }
        public Guid? ProductColorId { get; set; }
        public int CountStock { get; set; }

        #region Relationship
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class ProductImage : BaseModel
    {
        public string Caption { get; set; }
        public string ImageLink { get; set; }
        public bool MainImage { get; set; }
        public long FileSize { get; set; }
        public int Sort { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

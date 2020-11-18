using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class ProductInCategory
    {
        //[Key]
        //[ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        //[Key]
        //[ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

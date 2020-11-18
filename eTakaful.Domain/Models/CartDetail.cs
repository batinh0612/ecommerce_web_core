using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class CartDetail : BaseModel
    {
        #region Property
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Relationship
        [ForeignKey("Cart")]
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class OrderDetail : BaseModel
    {
        #region Property
        public int Quantity { get; set; }
        public string Voucher { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Relationship
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        #endregion
    }
}

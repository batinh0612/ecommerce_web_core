using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Order : BaseModel
    {
        #region Property
        public int OrderNumber { get; set; }
        public Payment PaymentType { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(11), MinLength(10)]
        public string Phone { get; set; }
        [MaxLength(50)]
        //public string Name { get; set; }
        public string Province { get; set; }
        public string Districts { get; set; }
        public string Ward { get; set; }
        public decimal Discount { get; set; }
        //public int ShoppingNumber { get; set; }
        public decimal FeeMount { get; set; }
        public string VoucherCode { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        #endregion

        #region Relationship
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}

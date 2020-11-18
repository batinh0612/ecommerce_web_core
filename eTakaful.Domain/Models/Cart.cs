using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Cart : BaseModel
    {
        #region Property
        public int ShoppingNumber { get; set; }
        public decimal FeeMount { get; set; }
        public decimal VoucherCode { get; set; }
        public decimal TotalPrice { get; set; }
        public ShoppingCartEnum CartStatus { get; set; }
        #endregion

        #region Realtionship
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Couspon")]
        public Guid CousponId { get; set; }
        public virtual Couspon Couspon { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        #endregion
    }
}

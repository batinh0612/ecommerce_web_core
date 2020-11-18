using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Customer : BaseModel
    {
        #region Property
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(11), MinLength(10)]
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        #endregion

        #region Relationship
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}

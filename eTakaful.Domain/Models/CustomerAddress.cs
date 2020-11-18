using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class CustomerAddress : BaseModel
    {
        #region Property
        [MaxLength(200)]
        public string Address { get; set; }
        public bool IsDefault { get; set; }
        #endregion

        #region Relationship
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        #endregion
    }
}

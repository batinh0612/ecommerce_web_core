using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class CousponProduct : BaseModel
    {
        #region Property
        #endregion

        #region Relationship
        public Guid CousponId { get; set; }
        public virtual Couspon Couspon { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}

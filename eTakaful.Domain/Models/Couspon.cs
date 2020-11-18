using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Couspon : BaseModel
    {
        #region Property
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Code { get; set; }
        public int PercentDiscount { get; set; }
        public string Description { get; set; }
        public bool ApplyAll { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        #endregion

        #region Relationship
        public virtual ICollection<CousponProduct> CousponProducts { get; set; }
        #endregion
    }
}

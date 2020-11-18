using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Supplier : BaseModel
    {
        #region Property
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string CodeName { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Fax { get; set; }
        #endregion

        #region Relationship
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Role : BaseModel
    {
        #region Property
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Relatioship
        public virtual ICollection<User> Users { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Comment : BaseModel
    {
        #region Property
        [Required]
        public string Content { get; set; }
        #endregion

        #region Relationship
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual  User User { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    public class User : BaseModel
    {
        #region Property
        [Required]
        [MaxLength(256)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        #endregion

        #region Relationship
        [ForeignKey("Role")]
        public Guid? RoleId { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}

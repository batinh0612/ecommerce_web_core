using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Category : BaseModel
    {
        #region Property
        public int Sort { get; set; }
        public bool IsDisplayHomePage { get; set; }
        public Guid? ParentId { get; set; }
        #endregion

        #region Relationship
        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual ICollection<ProductInCategory> ProductInCategories { get; set; }
        #endregion
    }
}

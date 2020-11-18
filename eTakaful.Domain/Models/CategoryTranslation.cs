using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class CategoryTranslation
    {
        #region Property
        public CategoryTranslation()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }

        #endregion

        #region Realtionship
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Language Language { get; set; }

        [ForeignKey("Language")]
        public string LanguageId { get; set; }
        #endregion
    }
}

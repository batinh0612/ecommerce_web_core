using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class ProductTranslation
    {
        #region Property
        public ProductTranslation()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Keyword { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string ShortDescription { get; set; }
        public ProductStatusEnum ProductStatus { get; set; }
        #endregion

        #region Relationship
        public virtual Product Product { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public virtual Language Language { get; set; }

        [ForeignKey("Language")]
        public string LanguageId { get; set; }
        #endregion
    }
}

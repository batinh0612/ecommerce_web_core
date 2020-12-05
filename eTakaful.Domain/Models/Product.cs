using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Product : BaseModel
    {
        #region Property
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(255)]
        public string Sku { get; set; }
        public DateTime PublicationDate { get; set; }
        public int? PercentDiscount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int Views { get; set; }
        [MaxLength(128)]
        public DateTime? ExpirationDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public bool IsFeatured { get; set; }
        #endregion

        #region Relation
        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("Manufacture")]
        public Guid ManufactureId { get; set; }
        public virtual Manufacture Manufacture { get; set; }

        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductInCategory> ProductInCategories { get; set; }
        public virtual ICollection<ProductTranslation> ProductTranslations { get; set; }
        #endregion
    }
}

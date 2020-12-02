using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Product
{
    public class ProductHomePageViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Sku { get; set; }

        public DateTime PublicationDate { get; set; }

        public int? PercentDiscount { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Views { get; set; }

        public string Keyword { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string Details { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }

        public string SupplierName { get; set; }

        public string ManufactureName { get; set; }

        public Guid? CategoryId { get; set; }

        public string ImageLink { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

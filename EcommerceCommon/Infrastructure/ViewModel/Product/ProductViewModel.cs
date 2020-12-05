using Ecommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        [Display(Name = "Sku")]
        public string Sku { get; set; }

        [Display(Name = "Ngày mở bán")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Chiết khấu")]
        public int? PercentDiscount { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Trạng thái")]
        public ProductStatusEnum ProductStatus { get; set; }

        [Display(Name = "Lượt xem")]
        public int Views { get; set; }

        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }

        [Display(Name = "Ngày hết hạn")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }

        [Display(Name = "Chi tiết")]
        public string Details { get; set; }

        [Display(Name = "Cân nặng")]
        public double Weight { get; set; }

        [Display(Name = "Chiều cao")]
        public double Height { get; set; }

        [Display(Name = "Chiều rộng")]
        public double Width { get; set; }

        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public string SupplierName { get; set; }

        [Display(Name = "Nhà sản xuất")]
        public string ManufactureName { get; set; }

        [Display(Name = "Danh mục sản phẩm")]
        public string CategoryName { get; set; }

        public Guid? CategoryId { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public string ImageLink { get; set; }

        public string LanguageId { get; set; }
    }
}

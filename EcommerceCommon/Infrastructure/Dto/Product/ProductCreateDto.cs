using Ecommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Product
{
    public class ProductCreateDto
    {
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Mã sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập mã sản phẩm")]
        public string Code { get; set; }

        [Display(Name = "Sku")]
        [Required(ErrorMessage = "Bạn phải nhập sku")]
        public string Sku { get; set; }

        [Display(Name = "Ngày mở bán")]
        [Required(ErrorMessage = "Bạn phải chọn ngày mở bán")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Display(Name = "Giảm giá (%)")]
        public int? PercentDiscount { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Bạn phải nhập giá")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn phải nhập số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Tình trạng")]
        //[Required(ErrorMessage = "Bạn phải chọn trạng thái")]
        public ProductStatusEnum ProductStatus { get; set; }

        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }

        [Display(Name = "Ngày ngừng bán")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả sản phẩm")]
        public string Description { get; set; }

        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả ngắn")]
        public string ShortDescription { get; set; }


        [Display(Name = "Màu sắc")]
        [Required(ErrorMessage = "Bạn phải chọn màu sắc")]
        public List<Guid> ProductColorId { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "Bạn phải chọn size")]
        public List<Guid> ProductSizeId { get; set; }

        public int CountStock { get; set; }

        [Display(Name = "Nhà cung cấp")]
        [Required(ErrorMessage = "Bạn phải chọn nhà cung cấp")]
        public Guid SupplierId { get; set; }

        [Display(Name = "Nhà sản xuất")]
        [Required(ErrorMessage = "Bạn phải chọn nhà sản xuất")]
        public Guid ManufactureId { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Bạn phải chọn danh mục sản phẩm")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Chi tiết")]
        [Required(ErrorMessage = "Bạn phải nhập chi tiết sản phẩm")]
        public string Details { get; set; }

        [Display(Name = "Seo alias")]
        public string SeoAlias { get; set; }

        [Display(Name = "Seo title")]
        public string SeoTitle { get; set; }

        [Display(Name = "Seo mô tả")]
        public string SeoDescription { get; set; }

        [Display(Name = "Ảnh")]
        [Required(ErrorMessage = "Bạn phải chọn ảnh")]
        public IFormFile ThumnailImage { get; set; }

        public string LanguageId { get; set; }
    }
}

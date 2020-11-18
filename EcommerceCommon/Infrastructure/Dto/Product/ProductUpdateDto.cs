using Ecommerce.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Product
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Từ khóa")]
        [Required(ErrorMessage = "Bạn phải nhập từ khóa")]
        public string Keyword { get; set; }

        [Display(Name = "Chi tiết")]
        [Required(ErrorMessage = "Bạn phải nhập chi tiết sản phẩm")]
        public string Details { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả")]
        public string Description { get; set; }

        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả ngắn")]
        public string ShortDescription { get; set; }

        [Display(Name = "Mô tả seo")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả seo")]
        public string SeoDescription { get; set; }

        [Display(Name = "Tiêu đề seo")]
        [Required(ErrorMessage = "Bạn phải nhập tiêu đề seo")]
        public string SeoTitle { get; set; }

        [Display(Name = "Seo alias")]
        [Required(ErrorMessage = "Bạn phải nhập seo alias")]
        public string SeoAlias { get; set; }

        [Display(Name = "Trạng thái")]
        public ProductStatusEnum ProductStatus { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public IFormFile ThumbnailImage { get; set; }

        public string ImageLink { get; set; }
    }
}

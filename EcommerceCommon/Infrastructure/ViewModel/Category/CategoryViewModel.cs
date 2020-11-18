using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Category
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Sắp xếp")]
        //public int Sort { get; set; }

        [Display(Name = "Trạng thái")]
        public bool IsDisplayHomePage { get; set; }

        [Display(Name = "Danh mục cha")]
        public Guid? ParentId { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public Status CommonStatus { get; set; }

        public bool IsDeleted { get; set; }

        [Display(Name = "Danh mục cha")]
        public string CategoryName { get; set; }

        public string LanguageId { get; set; }
    }
}

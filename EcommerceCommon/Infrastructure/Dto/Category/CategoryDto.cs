using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Category
{
    public class CategoryDto
    {
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
    }
}

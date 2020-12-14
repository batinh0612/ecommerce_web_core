using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Cart
{
    public class CartDto
    {
        public Guid ProductId { get; set; }
        public Guid? ProductSizeId { get; set; }
        public Guid? ProductColorId { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public string LanguageId { get; set; }
    }
}

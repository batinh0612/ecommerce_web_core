using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Cart
{
    public class CartDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public int Quantity { get; set; }
        public int? PercentDiscount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Cart
{
    public class ProductCartViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public decimal Price { get; set; }
        public int PercentDiscount { get; set; }
        public string SupplierName { get; set; }
        public int CountStock { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}

using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Cart
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int ShoppingNumber { get; set; }
        public decimal FeeMount { get; set; }
        public decimal VoucherCode { get; set; }
        public decimal TotalPrice { get; set; }
        public ShoppingCartEnum CartStatus { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}

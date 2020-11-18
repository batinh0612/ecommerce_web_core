using Ecommerce.Domain.Enums;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalOrder { get; set; }
        public List<NewUserRegisterViewModel> NewUserRegisters { get; set; }
        public List<ProductViewModel> NewProduct { get; set; }
        public decimal TotalInComeSystem { get; set; }

        public List<MostViewProductViewModel> MostViewProducts { get; set; }
        public List<NewOrderViewModel> NewOrders { get; set; }
    }

    public class MostViewProductViewModel
    {
        public string Code { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public int Quantity { get; set; }
    }

    public class NewOrderViewModel
    {
        public Guid OrderId { get; set; }
        public int OrderNumber { get; set; }

        [Display(Name ="Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public Payment PaymentType { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Discount { get; set; }
        public decimal FeeMount { get; set; }
        public string VoucherCode { get; set; }
    }

    public class NewUserRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

}

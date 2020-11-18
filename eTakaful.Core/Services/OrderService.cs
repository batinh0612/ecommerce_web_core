using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class OrderService : EcommerceServices<Order>, IOrderService
    {
        public OrderService(IRepository<Order> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

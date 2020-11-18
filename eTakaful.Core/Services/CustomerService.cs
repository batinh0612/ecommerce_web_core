using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class CustomerService : EcommerceServices<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

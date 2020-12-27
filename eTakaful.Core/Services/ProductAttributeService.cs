using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services
{
    public class ProductAttributeService : EcommerceServices<ProductAttribute>, IProductAttributeService
    {
        public ProductAttributeService(IRepository<ProductAttribute> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

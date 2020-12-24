using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services
{
    public class ProductSizeService : EcommerceServices<ProductSize>, IProductSizeService
    {
        public ProductSizeService(IRepository<ProductSize> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

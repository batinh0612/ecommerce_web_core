using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class ProductPriceService : EcommerceServices<ProductPrice>, IProductPriceService
    {
        public ProductPriceService(IRepository<ProductPrice> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

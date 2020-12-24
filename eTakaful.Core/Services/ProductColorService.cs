using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services
{
    public class ProductColorService : EcommerceServices<ProductColor>, IProductColorService
    {
        public ProductColorService(IRepository<ProductColor> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

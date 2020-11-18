using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class ProductImageService : EcommerceServices<ProductImage>, IProductImageService
    {
        public ProductImageService(IRepository<ProductImage> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

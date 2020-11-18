using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class ProductRatingService : EcommerceServices<ProductRating>, IProductRatingService
    {
        public ProductRatingService(IRepository<ProductRating> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

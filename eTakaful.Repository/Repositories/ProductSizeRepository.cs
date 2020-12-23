using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class ProductSizeRepository : BaseRepository<ProductSize>, IProductSizeReposiroty
    {
        public ProductSizeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

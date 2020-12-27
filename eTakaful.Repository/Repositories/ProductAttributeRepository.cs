using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class ProductAttributeRepository : BaseRepository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

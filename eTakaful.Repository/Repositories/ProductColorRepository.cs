using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class ProductColorRepository : BaseRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}

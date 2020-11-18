using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class CousponProductRepository : BaseRepository<CousponProduct>, ICousponProductRepository
    {
        public CousponProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}

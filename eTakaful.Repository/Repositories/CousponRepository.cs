using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class CousponRepository : BaseRepository<Couspon>, ICousponRepository
    {
        public CousponRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}

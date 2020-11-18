using Ecommerce.Domain;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class ManufactureRepository : IManufactureRepository
    {
        private readonly ApplicationDbContext DbContext;
        public ManufactureRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<ManufactureListItem>> GetAll()
        {
            var manufactures = DbContext.Manufactures.Select(x => new ManufactureListItem() { 
                Id = x.Id,
                Name = x.Name
            });

            return await manufactures.ToListAsync();
        }
    }
}

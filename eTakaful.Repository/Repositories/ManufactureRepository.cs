using Ecommerce.Domain;
using Ecommerce.Domain.Models;
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
    public class ManufactureRepository : BaseRepository<Manufacture>, IManufactureRepository
    {
        public ManufactureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ManufactureListItem>> GetAllManufactures()
        {
            var manufactures = DbContext.Manufactures.Select(x => new ManufactureListItem() { 
                Id = x.Id,
                Name = x.Name
            });

            return await manufactures.ToListAsync();
        }
    }
}

using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.ViewModel.ProductColor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Repositories
{
    public class ProductColorRepository : BaseRepository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ProductColorViewModel>> GetAllColor()
        {
            throw new NotImplementedException();
        }
    }
}

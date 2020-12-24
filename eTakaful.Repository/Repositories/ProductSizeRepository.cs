using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.ViewModel.ProductSize;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Repositories
{
    public class ProductSizeRepository : BaseRepository<ProductSize>, IProductSizeReposiroty
    {
        public ProductSizeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ProductSizeViewModel>> GetAllSize()
        {
            throw new NotImplementedException();
        }
    }
}

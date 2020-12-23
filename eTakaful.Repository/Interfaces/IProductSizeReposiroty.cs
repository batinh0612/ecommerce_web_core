using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.ViewModel.ProductSize;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProductSizeReposiroty : IRepository<ProductSize>
    {
        Task<List<ProductSizeViewModel>> GetAllSize();
    }
}

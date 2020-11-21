using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<List<SupplierListItem>> GetAllSuppliers();

        Task<List<Supplier>> GetAllSuppliersAsync();

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        Task<Supplier> Create(SupplierDto dto);
    }
}

using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface ISupplierService : IServices<Supplier>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<List<SupplierListItem>> GetAllSuppliers();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Supplier> Create(SupplierDto dto);
    }
}

using Ecommerce.Domain.Models;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
//using Ecommerce.WebAPI.Infrastructure.ApiResponse;
//using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface ISupplierApiClient
    {
        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <returns></returns>
        Task<List<Supplier>> GetAllSuppliers();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Supplier> Create(SupplierDto dto);
    }
}

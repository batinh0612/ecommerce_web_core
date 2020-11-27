using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using System;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface ISupplierApiClient
    {
        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> GetAllSuppliers();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> GetById(Guid id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Create(SupplierDto dto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Update(Guid id, SupplierDto dto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> Delete(Guid id);
    }
}

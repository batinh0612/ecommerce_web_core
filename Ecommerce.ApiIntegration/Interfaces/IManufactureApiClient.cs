using Ecommerce.Domain.Models;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface IManufactureApiClient
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> GetAll();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> GetById(Guid id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Create(ManufactureDto dto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApiResponse> Update(Guid id, ManufactureDto dto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}

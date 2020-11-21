using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.Supplier;

namespace Ecommerce.Service.Services
{
    public class SupplierService : EcommerceServices<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository) : base(supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<Supplier> Create(SupplierDto dto)
        {
            return _supplierRepository.Create(dto);
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public async Task<List<SupplierListItem>> GetAllSuppliers()
        {
            return await _supplierRepository.GetAllSuppliers();
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllSuppliersAsync();
        }
    }
}

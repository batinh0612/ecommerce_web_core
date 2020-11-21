using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.ApiResponse;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Supplier> Create(SupplierDto dto)
        {
            var supplier = new Supplier()
            {
                CodeName = dto.CodeName,
                Email = dto.Email,
                Name = dto.Name,
                Phone = dto.Phone,
                Fax = dto.Fax
            };

             DbContext.Add(supplier);
             await DbContext.SaveChangesAsync();
            return supplier;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public async Task<List<SupplierListItem>> GetAllSuppliers()
        {
            var suppliers = DbContext.Suppliers.Select(x => new SupplierListItem() { 
                Id = x.Id,
                Name = x.Name
            });

            return await suppliers.ToListAsync();
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            var suppliers = await DbContext.Suppliers.ToListAsync();

            return suppliers;
        }
    }
}

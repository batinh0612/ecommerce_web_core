using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService,
            IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet("get-all-supplier")]
        [Authorize]
        public async Task<ApiResponse> GetAll()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            if (suppliers != null && suppliers.Any())
            {
                return new ApiResponse("All supplier items", suppliers, 200);
            }

            return new ApiResponse("No item");
        }

        [HttpDelete("delete-supplier/{id}")]
        [Authorize]
        public async Task<ApiResponse> Delete(Guid id)
        {
            var user = await _supplierService.GetByIdAsync(id);
            if (user == null)
                return new ApiResponse($"Cannot found user with id: {id}");

            await _supplierService.DeleteAsync(user);
            return new ApiResponse("Delete user successful");
        }

        [HttpPost("add-supplier")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] SupplierDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = _mapper.Map<Supplier>(dto);
            supplier.UpdatedDate = null;

            var newSupplier = await _supplierService.AddAsync(supplier);
            return Ok(new ApiResponse("Create supplier successful", newSupplier));
        }

        [HttpPost("update-supplier/{id}")]
        [Authorize]
        public async Task<ApiResponse> Edit(Guid id, [FromBody] SupplierDto dto)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier != null)
            {
                var newSupplier = _mapper.Map(dto, supplier);
                newSupplier.UpdatedDate = DateTime.Now;
                await _supplierService.UpdateAsync(newSupplier);
                return new ApiResponse($"Record has been updated with id {id} to the database", newSupplier, 200);
            }
            return new ApiResponse($"Can't update category with id: {id}");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetById(Guid id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            return new ApiResponse("Success", supplier);
        }
    }
}

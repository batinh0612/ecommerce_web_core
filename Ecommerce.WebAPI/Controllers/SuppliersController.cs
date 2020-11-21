using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Interface;
//using EcommerceCommon.Infrastructure.ApiResponse;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using EcommerceCommon.Infrastructure.ViewModel.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet("get-all-supplier")]
        [AllowAnonymous]
        public async Task<ApiResponse> GetAll()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();

            if (suppliers != null && suppliers.Any())
            {
                //var result = _mapper.Map<List<SupplierViewModel>>(suppliers);
                return new ApiResponse("All supplier items", suppliers, 200);
            }

            return new ApiResponse("No item", null, 200);

            //var suppliers = await _supplierService.GetAllAsync();

            //if (suppliers != null && suppliers.Any())
            //{
            //    //var result = _mapper.Map<List<SupplierViewModel>>(suppliers);
            //    //return new ApiResponse("All supplier items", suppliers, 200);
            //    return Ok(suppliers);
            //}

            ////return new ApiResponse("No item", null, 200);
            //return BadRequest();
        }

        [HttpPost("add-supplier")]
        [AllowAnonymous]
        public async Task<ApiResponse> Create([FromBody] SupplierDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException("errors", 500);
            }

            var supplier = _mapper.Map<Supplier>(dto);
            supplier.UpdatedDate = null;

            await _supplierService.AddAsync(supplier);
            return new ApiResponse("New record has been created to the database", dto, 201);
        }

        [HttpPatch("update-supplier/{id}")]
        [AllowAnonymous]
        public async Task<ApiResponse> Edit(Guid id, [FromBody] SupplierDto dto)
        {
            try
            {
                var supplier = await _supplierService.GetByIdAsync(id);

                if (supplier != null)
                {
                    var newSupplier = _mapper.Map(dto, supplier);
                    newSupplier.UpdatedDate = DateTime.Now;
                    await _supplierService.UpdateAsync(newSupplier);
                    return new ApiResponse($"Record has been updated with id {id} to the database", dto, 201);
                }
                return new ApiResponse($"Can't update category with id: {id}", dto, 200);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex, 400);
            }
        }

        [HttpDelete("delete-supplier/{id}")]
        [AllowAnonymous]
        public async Task<ApiResponse> Delete(Guid id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            if (supplier != null)
            {
                await _supplierService.DeleteAsync(supplier);
                return new ApiResponse("Removed item", 200);
            }

            return new ApiResponse("Can't delete item", null, 200);
        }
    }
}

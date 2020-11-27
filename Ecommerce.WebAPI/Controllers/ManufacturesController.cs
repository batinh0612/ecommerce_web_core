using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturesController : ControllerBase
    {
        private readonly IManufactureService manufactureService;
        private readonly IMapper mapper;

        public ManufacturesController(IManufactureService manufactureService, IMapper mapper)
        {
            this.manufactureService = manufactureService;
            this.mapper = mapper;
        }

        [HttpGet("get-all-manufactures")]
        [Authorize]
        public async Task<ApiResponse> GetAll()
        {
            var manufactures = await manufactureService.GetAllAsync();
            if (manufactures != null && manufactures.Any())
            {
                return new ApiResponse("List all manufactures", manufactures, 200);
            }

            return new ApiResponse("No item");
        }

        [HttpPost("add-manufacture")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ManufactureDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacture = mapper.Map<Manufacture>(dto);
            manufacture.UpdatedDate = null;

            var newManufacture = await manufactureService.AddAsync(manufacture);
            return Ok(new ApiResponse("Create manufacture successful", newManufacture, 200));
        }

        [HttpPost("update-manufacture/{id}")]
        [Authorize]
        public async Task<ApiResponse> Edit(Guid id, [FromBody]ManufactureDto dto)
        {
            var supplier = await manufactureService.GetByIdAsync(id);
            if (supplier != null)
            {
                var newSupplier = mapper.Map(dto, supplier);
                newSupplier.UpdatedDate = DateTime.Now;
                await manufactureService.UpdateAsync(newSupplier);
                return new ApiResponse($"Record has been updated with id {id} to the database", newSupplier, 200);
            }
            return new ApiResponse($"Can't update manufacture with id: {id}");
        }

        [HttpDelete("delete-manufacture-by-id/{id}")]
        [Authorize]
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var manufacture = await manufactureService.GetByIdAsync(id);
                if (manufacture != null)
                {
                    await manufactureService.DeleteAsync(manufacture);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ApiResponse> GetById(Guid id)
        {
            var manufacture = await manufactureService.GetByIdAsync(id);
            return new ApiResponse("Success", manufacture, 200);
        }
    }
}

using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class ManufactureService : IManufactureService
    {
        private readonly IManufactureRepository _manufactureRepository;
        public ManufactureService(IManufactureRepository manufactureRepository)
        {
            _manufactureRepository = manufactureRepository;
        }

        public async Task<List<ManufactureListItem>> GetAll()
        {
            return await _manufactureRepository.GetAll();
        }
    }
}

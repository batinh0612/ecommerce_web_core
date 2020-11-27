using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class ManufactureService : EcommerceServices<Manufacture>, IManufactureService
    {
        private readonly IManufactureRepository _manufactureRepository;

        public ManufactureService(IManufactureRepository manufactureRepository, IRepository<Manufacture> repository) : base(repository)
        {
            _manufactureRepository = manufactureRepository;
        }

        public async Task<List<ManufactureListItem>> GetAllManufactures()
        {
            return await _manufactureRepository.GetAllManufactures();
        }
    }
}

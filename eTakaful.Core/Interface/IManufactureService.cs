using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface IManufactureService : IServices<Manufacture>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<List<ManufactureListItem>> GetAllManufactures();
    }
}

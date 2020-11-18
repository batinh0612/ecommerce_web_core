using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class CousponProductService : EcommerceServices<CousponProduct>, ICousponProductService
    {
        public CousponProductService(IRepository<CousponProduct> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class CousponService : EcommerceServices<Couspon>, ICousponService
    {
        public CousponService(IRepository<Couspon> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

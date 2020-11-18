using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class ConfigService : EcommerceServices<Config>, IConfigService
    {
        public ConfigService(IRepository<Config> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

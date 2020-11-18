using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class LanguageService : EcommerceServices<Language>, ILanguageService
    {
        public LanguageService(IRepository<Language> baseReponsitory) : base(baseReponsitory)
        {
        }
    }
}

using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.ViewModel.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Admin.Models
{
    public class NavigationViewModel
    {
        public IQueryable<Language> Languages { get; set; }

        public string CurrentLanguageId { get; set; }

        public string ReturnUrl { get; set; }
    }
}

using EcommerceCommon.Infrastructure.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Models
{
    public class HomePageViewModel
    {
        public List<ProductHomePageViewModel> LatestProducts { get; set; }

        public List<ProductHomePageViewModel> FeatureProducts { get; set; }
    }
}

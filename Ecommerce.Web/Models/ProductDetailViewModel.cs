using EcommerceCommon.Infrastructure.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Models
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Details { get; set; }
        public List<ProductColorItem> ListColors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.ViewModel.Supplier
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

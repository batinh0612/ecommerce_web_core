using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Supplier
{
    public class SupplierDto
    {
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        //public ICollection<Product> Products { get; set; }
    }
}

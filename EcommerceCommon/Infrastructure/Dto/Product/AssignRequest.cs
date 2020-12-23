using EcommerceCommon.Infrastructure.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Product
{
    public class AssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectedItem> Assigns { get; set; } = new List<SelectedItem>();
    }
}

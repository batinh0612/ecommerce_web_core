using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Common
{
    public class SelectedItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}

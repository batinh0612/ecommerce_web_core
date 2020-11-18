using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Common
{
    public class QueryListResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Count { get; set; }
    }
}

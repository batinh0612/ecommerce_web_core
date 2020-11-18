using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceCommon.Infrastructure.Dto.Common
{
    public class QueryBase<T>
    {
        public T Filter { get; set; }
        public string OrderBy { get; set; }
        public SortType Direction { get; set; } = SortType.Desc;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public bool ShowTotal { get; set; }
    }
    public enum SortType
    {
        Desc,
        Asc
    }

    public class BaseSearch
    {
        public string Search { get; set; }
    }

    public class BaseSearchInt
    {
        public int Search { get; set; }
    }
}

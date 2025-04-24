using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        private const int DefaultPageSize = 5;

        private const int MaxPageIndex = 10;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOption Option { get; set; }
        public string? SearchValue { get; set; }
        public int PageIndex { get; set; } = 1;
        public int pageSize { get; set; } = DefaultPageSize;
        public int PageSize 
        {
            get { return pageSize; }
            set {  pageSize = value > MaxPageIndex ? MaxPageIndex : value; } 
        }
    }
}

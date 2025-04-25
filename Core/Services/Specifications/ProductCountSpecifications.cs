using DomianLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
     class ProductCountSpecifications : BaseSpecifications<Product,int>
    {
        public ProductCountSpecifications(ProductQueryParams queryParams):base(p => (!queryParams.BrandId.HasValue || queryParams.BrandId == queryParams.BrandId)
        && (!queryParams.TypeId.HasValue || queryParams.TypeId == queryParams.TypeId)
        && (string.IsNullOrWhiteSpace(queryParams.SearchValue) || p.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {
            
        }
    }
}

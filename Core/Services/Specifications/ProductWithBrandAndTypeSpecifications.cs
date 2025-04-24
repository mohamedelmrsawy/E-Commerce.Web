using DomianLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product , int>
    {
        public ProductWithBrandAndTypeSpecifications(ProductQueryParams option) : base(p => (!option.BrandId.HasValue || option.BrandId == option.BrandId) && (!option.TypeId.HasValue || option.TypeId == option.TypeId)
        && (string.IsNullOrWhiteSpace(option.SearchValue) || p.Name.ToLower().Contains(option.SearchValue.ToLower())))
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);

            switch(option.Option)
            {
                case ProductSortingOption.NameAsc:
                    AddOrderBy(P => P.Name);
                    break;
                case ProductSortingOption.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOption.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOption.PriceDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                default:
                    break;
            }
            ApplyPagination(option.PageSize,option.PageIndex);
        }

        public ProductWithBrandAndTypeSpecifications(int id):base(p=>p.Id == id) 
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);
        }
    }
}

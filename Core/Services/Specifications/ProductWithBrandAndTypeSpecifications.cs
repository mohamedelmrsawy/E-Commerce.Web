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
        public ProductWithBrandAndTypeSpecifications(int? BrandId, int? TypeId, ProductSortingOption option) :base(p=>(!BrandId.HasValue || p.BrandId == BrandId ) && (!TypeId.HasValue || p.TypeId == TypeId ))
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);

            switch(option)
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

        }

        public ProductWithBrandAndTypeSpecifications(int id):base(p=>p.Id == id) 
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);
        }
    }
}

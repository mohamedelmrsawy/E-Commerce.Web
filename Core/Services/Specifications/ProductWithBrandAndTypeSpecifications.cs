using DomianLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product , int>
    {
        public ProductWithBrandAndTypeSpecifications(int? BrandId, int? TypeId) :base(p=>(!BrandId.HasValue || p.BrandId == BrandId ) && (!TypeId.HasValue || p.TypeId == TypeId ))
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);
        }

        public ProductWithBrandAndTypeSpecifications(int id):base(p=>p.Id == id) 
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);
        }
    }
}

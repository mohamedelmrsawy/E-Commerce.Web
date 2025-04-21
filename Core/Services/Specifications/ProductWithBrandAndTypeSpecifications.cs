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
        public ProductWithBrandAndTypeSpecifications():base(null)
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

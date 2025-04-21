using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(int? BrandId, int? TypeId);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
        Task<IEnumerable<PrandDto>> GetAllPrandsAsync();
    }
}

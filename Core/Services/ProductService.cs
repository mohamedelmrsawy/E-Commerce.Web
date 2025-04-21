using AutoMapper;
using DomianLayer.Contracts;
using DomianLayer.Models;
using ServiceAbstraction;
using Services.Specifications;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<PrandDto>> GetAllPrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand , int>();
            var Brands = await repo.GetAllAsync();
            var BrandsDto = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<PrandDto>>(Brands); 
            return BrandsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var Specifications = new ProductWithBrandAndTypeSpecifications();
            var Products = await _unitOfWork.GetRepository<Product , int>().GetAllAsync(Specifications);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var Specifications = new ProductWithBrandAndTypeSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetbyIdAsync(Specifications);
            return _mapper.Map<Product , ProductDto>(product);
        }
    }
}

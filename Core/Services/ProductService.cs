using AutoMapper;
using DomianLayer.Contracts;
using DomianLayer.Exceptions;
using DomianLayer.Models;
using ServiceAbstraction;
using Services.Specifications;
using Shared;
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

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams option)
        {
            var Repo = _unitOfWork.GetRepository<Product,int>();
            var Specifications = new ProductWithBrandAndTypeSpecifications( option);
            var Products = await _unitOfWork.GetRepository<Product , int>().GetAllAsync(Specifications);            
            var AllProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
            var ProductCount = Products.Count();
            var TotalCount = await Repo.CountAsync(new ProductCountSpecifications(option));
            return new PaginatedResult<ProductDto>(option.PageIndex , ProductCount , TotalCount, AllProducts);
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
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }
            return _mapper.Map<Product , ProductDto>(product);
        }
    }
}

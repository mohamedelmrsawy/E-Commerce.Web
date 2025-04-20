using AutoMapper;
using DomianLayer.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, option => option.MapFrom(src => src.productBrand.Name))
                .ForMember(dest => dest.TypeName, option => option.MapFrom(src => src.productType.Name))
                .ForMember(dest => dest.PictureUrl, option => option.MapFrom<PictureUrlResolver>());

            CreateMap<ProductType, TypeDto>();
            CreateMap<ProductBrand, PrandDto>();
                
        }
    }
}

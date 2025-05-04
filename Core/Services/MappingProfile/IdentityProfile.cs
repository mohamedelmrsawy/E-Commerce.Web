using AutoMapper;
using DomianLayer.Models.IdentityModule;
using Shared.DTO.IdentityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    internal class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Address , AddressDto>().ReverseMap();
        }
    }
}

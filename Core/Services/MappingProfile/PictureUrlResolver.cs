using AutoMapper;
using DomianLayer.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Services.MappingProfile
{
    public class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string>
    {
       

        // https://localhost:7050/
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl)) 
                return string.Empty;
            else
            {
                //var url = $"https://localhost:7050/{source.PictureUrl}";
                var url = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
                return url;
            }
        }
    }
}

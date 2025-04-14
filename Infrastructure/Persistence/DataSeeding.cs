using DomianLayer.Contracts;
using DomianLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StorDbContext _dbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try 
            { 
                if(_dbContext.Database.GetPendingMigrations().Any())
            {
                _dbContext.Database.Migrate();
            }

                if (_dbContext.productBrands.Any())
            {
                var ProductBrandData = File.ReadAllText(@"D:..\Infrastructure\Persistence\Data\DataSeed\brands.json");

                var ProductBrands = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandData);

                if(ProductBrands is not null && ProductBrands.Any())
                {
                    _dbContext.productBrands.AddRange(ProductBrands);
                }
            }

                if (_dbContext.productTypes.Any())
            {
                var ProductTypeData = File.ReadAllText(@"D:..\Infrastructure\Persistence\Data\DataSeed\types.json");

                var ProductTypes = JsonSerializer.Deserialize<List<ProductBrand>>(ProductTypeData);

                if (ProductTypes is not null && ProductTypes.Any())
                {
                    _dbContext.productBrands.AddRange(ProductTypes);
                }
            }

                if (_dbContext.producs.Any())
            {
                var ProductData = File.ReadAllText(@"D:..\Infrastructure\Persistence\Data\DataSeed\Products.json");

                var Products = JsonSerializer.Deserialize<List<ProductBrand>>(ProductData);

                if (Products is not null && Products.Any())
                {
                    _dbContext.productBrands.AddRange(Products);
                }
            }
            }
            catch(Exception ex) 
            {

            }
            
        }
    }
}

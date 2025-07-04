﻿using DomianLayer.Contracts;
using DomianLayer.Models;
using DomianLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
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
    public class DataSeeding(StorDbContext _dbContext , UserManager<ApplicationUser> _userManager , RoleManager<IdentityRole> _roleManager) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try 
            {
                var PendingMigration = await _dbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigration.Any())
            {
                _dbContext.Database.MigrateAsync();
            }


                if (_dbContext.productBrands.Any())
            {
                //var ProductBrandData =await File.ReadAllTextAsync(@"D:..\Infrastructure\Persistence\Data\DataSeed\brands.json");
                var ProductBrandData = File.OpenRead(@"D:..\Infrastructure\Persistence\Data\DataSeed\brands.json");

                var ProductBrands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);

                if(ProductBrands is not null && ProductBrands.Any())
                {
                   await _dbContext.productBrands.AddRangeAsync(ProductBrands);
                }
            }


                if (_dbContext.productTypes.Any())
            {
                var ProductTypeData = File.OpenRead(@"D:..\Infrastructure\Persistence\Data\DataSeed\types.json");

                var ProductTypes =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductTypeData);

                if (ProductTypes is not null && ProductTypes.Any())
                {
                   await _dbContext.productBrands.AddRangeAsync(ProductTypes);
                }
            }


                if (_dbContext.producs.Any())
            {
                var ProductData = File.OpenRead(@"D:..\Infrastructure\Persistence\Data\DataSeed\Products.json");

                var Products =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductData);

                if (Products is not null && Products.Any())
                {
                    await _dbContext.productBrands.AddRangeAsync(Products);
                }
            }

                await _dbContext.SaveChangesAsync();

            }
            catch(Exception ex) 
            {

            }
            
        }

        public async Task IdentityDataSeedAsync()
        {
            if (!_roleManager.Roles.Any())
            {
               await _roleManager.CreateAsync(new IdentityRole("Admin"));
               await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            if (!_userManager.Users.Any())
            {
                var user01 = new ApplicationUser()
                {
                    Email = "mohamed@gmail.com",
                    DisplayName = "mohamed ali",
                    PhoneNumber = "1234567890",
                    UserName = "mohamedAli"
                };

                await _userManager.CreateAsync(user01, "p@ssw0rd");
                await _userManager.AddToRoleAsync(user01, "Admin");
            }

        }
    }
}

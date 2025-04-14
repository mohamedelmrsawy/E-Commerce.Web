using DomianLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class StorDbContext : DbContext
    {
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<Product> producs { get; set; }



        public StorDbContext(DbContextOptions<StorDbContext> Options) :base(Options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssembleReference).Assembly);
        }
    }
}

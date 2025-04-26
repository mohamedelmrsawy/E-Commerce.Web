
using DomianLayer.Contracts;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repository;
using ServiceAbstraction;
using Services;
using Services.MappingProfile;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            #region Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StorDbContext>(Option =>
            {
                Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(Services.AssembleReference).Assembly);
            builder.Services.Configure<ApiBehaviorOptions>((option) =>
            {
                option.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorRespnse;
            });
            #endregion

            var app = builder.Build();

            var Scoope = app.Services.CreateScope();
            var ObjectOfDataSeeding = Scoope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await ObjectOfDataSeeding.DataSeedAsync();

            #region Configure the HTTP request pipeline.

            //app.Use(async (RequestContext, NextMiddleWare) =>
            //{
            //    Console.WriteLine("Request Under Processing");
            //    await NextMiddleWare.Invoke();
            //    Console.WriteLine("Waiting Response");
            //    Console.WriteLine(RequestContext.Response.Body);

            //});



            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}

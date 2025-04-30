
using DomianLayer.Contracts;
using E_Commerce.Web.Extensions;
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
            builder.Services.AddSwaggerServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddlicationServic();
            builder.Services.AddWebAppLicationServices();         
            #endregion

            var app = builder.Build();

            await app.SeedDataBaseAsync();

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

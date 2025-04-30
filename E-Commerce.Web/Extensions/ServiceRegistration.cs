using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Extensions
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }

        public static IServiceCollection AddWebAppLicationServices(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>((option) =>
            {
                option.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorRespnse;
            });
            return Services;
        }

    }
}

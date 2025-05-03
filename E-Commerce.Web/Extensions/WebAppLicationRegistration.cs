using DomianLayer.Contracts;

namespace E_Commerce.Web.Extensions
{
    public static class WebAppLicationRegistration
    {

        public static async Task<WebApplication> SeedDataBaseAsync(this WebApplication app)
        {
            using var Scoope = app.Services.CreateScope();
            var ObjectOfDataSeeding = Scoope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await ObjectOfDataSeeding.DataSeedAsync();
            await ObjectOfDataSeeding.IdentityDataSeedAsync();
            return app;
        }

        

    }
}

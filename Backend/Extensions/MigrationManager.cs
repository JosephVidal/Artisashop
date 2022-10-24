using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Extensions
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>())
                {
                    try
                    {
                        if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                            appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw new Exception(ex.Message);
                    }
                }
            }

            return webApp;
        }
    }
}
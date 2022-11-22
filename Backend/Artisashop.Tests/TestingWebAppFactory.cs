namespace Artisashop.Tests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<StoreDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<StoreDbContext>(options =>
                {
                    options.UseSqlite("Data Source=./tests.db");
                    // options.UseInMemoryDatabase("InMemoryDbTest");
                });
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                using var appContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                try
                {
                    appContext.Database.EnsureDeleted();
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
        }
    }
}

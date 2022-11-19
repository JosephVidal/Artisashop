using Artisashop.Models;
using Bogus;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artisashop;

public static class Seeder
{
    /// <summary>
    /// Seeds the base roles for the application.
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <exception cref="Exception"></exception>
    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        // Create Roles
        using var storeDbContext = scope.ServiceProvider.GetService<StoreDbContext>();

        if (storeDbContext == null)
        {
            return;
        }

        await storeDbContext.Database.EnsureDeletedAsync();
        await storeDbContext.Database.MigrateAsync();

        foreach (string role in Roles.AllRoles)
        {
            var roleStore = new RoleStore<IdentityRole>(storeDbContext);
            roleStore.AutoSaveChanges = true;

            if (!storeDbContext.Roles.Any(r => r.Name == role))
            {
                var result = await roleStore.CreateAsync(new IdentityRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                });
                if (!result.Succeeded)
                {
                    throw new Exception($"Error creating role {role} : {result.Errors.First().Description}");
                }
            }

            await storeDbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Génère les utilisateurs ADMIN de test.
    /// </summary>
    /// <remarks>
    /// Tous les utilisateurs ont le même email, mais leur username n'est pas leur email.
    /// </remarks>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoAdminUsersAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        var Admins = new List<Account>()
        {
            new()
            {
                Email = "contact@artisashop.fr",
                UserName = "TCOLONNA",
                Firstname = "Thomas",
                Lastname = "Colonna",
            },
            new()
            {
                Email = "contact@artisashop.fr",
                UserName = "HGVALOT",
                Firstname = "Helena",
                Lastname = "Ganeman-Valot",
            },
            new()
            {
                Email = "contact@artisashop.fr",
                UserName = "JVIDAL",
                Firstname = "Joseph",
                Lastname = "Vidal",
            },
            new()
            {
                Email = "contact@artisashop.fr",
                UserName = "JEPP",
                Firstname = "Jean",
                Lastname = "Epp",
            },
            new()
            {
                Email = "contact@artisashop.fr",
                UserName = "GFISCHER",
                Firstname = "Guillaume",
                Lastname = "Fischer",
            },
            new()
            {
                Email = "contact@artisashop.fr",
                UserName = "YOSMONT",
                Firstname = "Yann",
                Lastname = "Osmont",
            },
        };

        foreach (var account in Admins)
        {
            var password = new PasswordHasher<Account>();
            var hashed = password.HashPassword(account, "Artisashop@2022");
            account.PasswordHash = hashed;

            var userStore = new UserStore<Account>(dbContext);
            await userStore.CreateAsync(account);
            await AssignRoles(serviceProvider, account.Id, new[] { Roles.Admin, Roles.User });
            await dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Génère les données de remplissage de l'application.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoDataAsync(IServiceProvider serviceProvider)
    {
        await SeedDemoStyles(serviceProvider);
        await SeedDemoUsers(serviceProvider);
        await SeedDemoSellers(serviceProvider);
        await SeedDemoProducts(serviceProvider);
    }

    /// <summary>
    /// Seeds the style entities.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoStyles(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        // Create styles for products
        var stylesFaker = new Faker<Style>()
            .RuleFor(o => o.Name, f => f.Commerce.ProductMaterial())
            .RuleFor(o => o.Description, f => f.Commerce.ProductDescription());
        var styles = stylesFaker.Generate(50);
        dbContext.Styles.AddRange(styles);
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Seeds the user entities.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoUsers(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        // Create users
        var userFaker = new Faker<Account>()
            .RuleFor(o => o.Id, f => Guid.NewGuid().ToString())
            .RuleFor(o => o.UserName, f => f.Internet.Email())
            .RuleFor(o => o.Email, (f, o) => o.UserName)
            .RuleFor(o => o.Firstname, f => f.Name.FirstName())
            .RuleFor(o => o.Lastname, f => f.Name.LastName())
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.Biography, f => f.Lorem.Paragraph())
            .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Job, f => f.Name.JobTitle())
            .RuleFor(o => o.EmailConfirmed, true)
            .RuleFor(o => o.PhoneNumberConfirmed, true)
            .RuleFor(o => o.PasswordHash, f => new PasswordHasher<Account>().HashPassword(null, "Artisashop@2022"));
        var users = userFaker.Generate(100);

        // Formats the account's data and adds it to the database
        foreach (var account in users)
        {
            var password = new PasswordHasher<Account>();
            var hashed = password.HashPassword(account, "Artisashop@2022");
            account.PasswordHash = hashed;

            var userStore = new UserStore<Account>(dbContext);
            await userStore.CreateAsync(account);
            await AssignRoles(scope.ServiceProvider, account.Id, new[] { Roles.User });

            await dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Adds the seller roles to a number of users.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoSellers(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        var sellers = dbContext.Users.Take(10).ToList();
        foreach (var account in sellers)
        {
            await AssignRoles(scope.ServiceProvider, account.Id, new[] { Roles.Seller });
        }
    }

    /// <summary>
    /// Seeds the product entities.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoProducts(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        UserManager<Account> userManager = scope.ServiceProvider.GetService<UserManager<Account>>()!;
        var sellers = await userManager.GetUsersInRoleAsync(Roles.Seller);

        // Create products
        var productsFaker = new Faker<Product>()
            .RuleFor(o => o.Name, f => f.Commerce.ProductName())
            .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
            .RuleFor(o => o.Price, f => f.Random.Decimal(0, 1000))
            .RuleFor(o => o.Quantity, f => f.Random.Int(0, 1000))
            .RuleFor(o => o.Craftsman, f => f.PickRandom(sellers))
            .RuleFor(o => o.Styles, f => f.PickRandom(dbContext.Styles.Select(x => new ProductStyle() { StyleId = x.Id}).ToList(), 3));
        var products = productsFaker.Generate(100);
        dbContext.Products.AddRange(products);
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Assigns the specified roles to the specified user.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="id"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string id, string[] roles)
    {
        UserManager<Account> userManager = services.GetService<UserManager<Account>>()!;
        Account user = await userManager.FindByIdAsync(id);
        var result = await userManager.AddToRolesAsync(user, roles);

        return result;
    }
}
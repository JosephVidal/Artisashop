using Artisashop.Identity;
using Artisashop.Models;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace Artisashop;

public static class Seed
{

    /// <summary>
    /// Configures the roles for the Identity system.
    /// </summary>
    /// <param name="roleManager"></param>
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("User"));
        await roleManager.CreateAsync(new IdentityRole("Seller"));
        await roleManager.CreateAsync(new IdentityRole("Partner"));
    }

    public static async Task SeedUsersAsync(UserManager<Account> userManager)
    {
        var admin = new Account()
        {
            Email = "thomas.colonna@epitech.eu",
            UserName = "Admin",
            Firstname = "Thomas",
            Lastname = "Colonna"
        };

        await userManager.CreateAsync(admin, "Password123!");
        await userManager.AddToRoleAsync(admin, Roles.Admin);
    }

    public static async Task SeedDemoDataAsync(UserManager<Account> userManager, StoreDbContext context)
    {
        var users = new Faker<Account>()
            .StrictMode(true)
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.UserName, f => f.Internet.UserName())
            .RuleFor(o => o.Firstname, f => f.Name.FirstName())
            .RuleFor(o => o.EmailConfirmed, true);
        context.Users.AddRange(users.Generate(50));

        var styles = new Faker<Style>()
            .StrictMode(true)
            .RuleFor(o => o.Name, f => f.Commerce.ProductMaterial())
            .RuleFor(o => o.Description, f => f.Commerce.ProductDescription());
        context.Styles.AddRange(styles.Generate(50));

        var products = new Faker<Product>()
            .StrictMode(true)
            .RuleFor(o => o.Name, f => f.Commerce.ProductName())
            .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
            .RuleFor(o => o.Price, f => f.Random.Decimal(0, 1000))
            .RuleFor(o => o.Quantity, f => f.Random.Int(0, 1000))
            .RuleFor(o => o.Craftsman,
                f => f.PickRandom(context.Users.Where(user => user.Role == Account.UserType.CRAFTSMAN).ToList()));
        context.Products.AddRange(products.Generate(100));
    }
}
using Artisashop.Models;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace Artisashop;

public static class Seeder
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

    public static async Task SeedDemoDataAsync(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager, StoreDbContext context)
    {
        // Create users
        var userFaker = new Faker<Account>()
            .StrictMode(true)
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.UserName, f => f.Internet.UserName())
            .RuleFor(o => o.Firstname, f => f.Name.FirstName())
            .RuleFor(o => o.EmailConfirmed, true);
        context.Users.AddRange(userFaker.Generate(50));

        // Assign some users to the seller role
        foreach (var account in context.Users.Take(10))
        {
            await userManager.AddToRoleAsync(account, Roles.Seller);
        }
        var sellers = await userManager.GetUsersInRoleAsync(Roles.Seller);

        // Create styles for products
        var styles = new Faker<Style>()
            .StrictMode(true)
            .RuleFor(o => o.Name, f => f.Commerce.ProductMaterial())
            .RuleFor(o => o.Description, f => f.Commerce.ProductDescription());
        context.Styles.AddRange(styles.Generate(50));

        // Create products
        var products = new Faker<Product>()
            .StrictMode(true)
            .RuleFor(o => o.Name, f => f.Commerce.ProductName())
            .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
            .RuleFor(o => o.Price, f => f.Random.Decimal(0, 1000))
            .RuleFor(o => o.Quantity, f => f.Random.Int(0, 1000))
            .RuleFor(o => o.Craftsman, f => f.PickRandom(sellers));
        context.Products.AddRange(products.Generate(100));
    }
}
using Artisashop.Models;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace Artisashop;

public static class Seed
{
    private const string ADMIN_EMAIL = "thomas.colonna@epitech.eu";
    private const string ADMIN_PASSWORD = "Password123!";
    private const string ADMIN_USERNAME = "Admin";
    private const string ADMIN_FIRSTNAME = "Thomas";

    public static async Task SeedData(UserManager<Account> userManager, StoreDbContext context)
    {
        var admin = new Faker<Account>()
            .StrictMode(true)
            .RuleFor(o => o.Email, f => ADMIN_EMAIL)
            .RuleFor(o => o.UserName, f => ADMIN_USERNAME)
            .RuleFor(o => o.Firstname, f => ADMIN_FIRSTNAME)
            .RuleFor(o => o.EmailConfirmed, true)
            .RuleFor(o => o.Role, f => Account.UserType.ADMIN).Generate(1).First();
        await userManager.CreateAsync(admin, ADMIN_PASSWORD);

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
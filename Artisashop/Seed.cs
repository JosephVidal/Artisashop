using Artisashop.Models;
using Bogus;

namespace Artisashop.Data;

public static class Seed
{
    public static void SeedData(StoreDbContext context)
    {
        var users = new Faker<Account>()
            .StrictMode(true)
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.UserName, f => f.Internet.UserName())
            .RuleFor(o => o.Firstname, f => f.Name.FirstName())
            .RuleFor(o => o.EmailConfirmed, true)
            .RuleFor(o => o.Role, Account.UserType.CRAFTSMAN);

        context.Users.AddRange(users.Generate(10));

        var products = new Faker<Product>()
        .StrictMode(true)
        .RuleFor(o => o.Name, f => f.Commerce.ProductName())
        .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
        .RuleFor(o => o.Price, f => f.Random.Decimal(0, 1000))
        .RuleFor(o => o.Quantity, f => f.Random.Int(0, 1000))
        .RuleFor(o => o.Craftsman, f => f.PickRandom(context.Users.ToList()));

        context.Products.AddRange(products.Generate(100));

        
    }
}
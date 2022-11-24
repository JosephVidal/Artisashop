using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Bogus;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Duende.IdentityServer.Models.IdentityResources;

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
                Email = "thomas@artisashop.fr",
                Firstname = "Thomas",
                Lastname = "Colonna",
                Suspended = false,
                Validation = false
            },
            new()
            {
                Email = "helena@artisashop.fr",
                Firstname = "Helena",
                Lastname = "Ganeman-Valot",
                Suspended = false,
                Validation = false
            },
            new()
            {
                Email = "joseph@artisashop.fr",
                Firstname = "Joseph",
                Lastname = "Vidal",
                Suspended = false,
                Validation = false
            },
            new()
            {
                Email = "jean@artisashop.fr",
                Firstname = "Jean",
                Lastname = "Epp",
                Suspended = false,
                Validation = false
            },
            new()
            {
                Email = "guillaume@artisashop.fr",
                Firstname = "Guillaume",
                Lastname = "Fischer",
                Suspended = false,
                Validation = false
            },
            new()
            {
                Email = "yann@artisashop.fr",
                Firstname = "Yann",
                Lastname = "Osmont",
                Suspended = false,
                Validation = false
            },
        };

        foreach (var account in Admins)
        {
            var password = new PasswordHasher<Account>();
            var hashed = password.HashPassword(account, "Artisashop@2022");
            account.PasswordHash = hashed;
            account.UserName = account.Email;

            var userStore = new UserStore<Account>(dbContext);
            await userStore.CreateAsync(account);
            await AssignRoles(serviceProvider, account.Id, new[] { Roles.Admin });
            await dbContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Génère les données de remplissage de l'application.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoDataAsync(IServiceProvider serviceProvider)
    {
        // await SeedDemoStyles(serviceProvider);
        await SeedDemoUsers(serviceProvider);
        await SeedDemoSellers(serviceProvider);
        await SeedDemoProducts(serviceProvider);
    }

    // /// <summary>
    // /// Seeds the style entities.
    // /// </summary>
    // /// <param name="serviceProvider"></param>
    // public static async Task SeedDemoStyles(IServiceProvider serviceProvider)
    // {
    //     using var scope = serviceProvider.CreateScope();
    //     using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    //
    //     // Create styles for products
    //     var stylesFaker = new Faker<Style>()
    //         .RuleFor(o => o.Name, f => f.Commerce.ProductMaterial())
    //         .RuleFor(o => o.Description, f => f.Commerce.ProductDescription());
    //     var styles = stylesFaker.Generate(50);
    //     dbContext.Styles.AddRange(styles);
    //     await dbContext.SaveChangesAsync();
    // }

    /// <summary>
    /// Seeds the user entities.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task SeedDemoUsers(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

        // Create user
        var userFaker = new Faker<Account>()
            .RuleFor(o => o.Id, f => Guid.NewGuid().ToString())
            .RuleFor(o => o.UserName, f => f.Internet.Email())
            .RuleFor(o => o.Email, (f, o) => o.UserName)
            .RuleFor(o => o.Firstname, f => f.Name.FirstName())
            .RuleFor(o => o.Lastname, f => f.Name.LastName())
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.Biography, f => f.Lorem.Paragraph())
            .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Job, f => DemoJob[f.Random.Int(0, DemoJob.Length - 1)])
            .RuleFor(o => o.EmailConfirmed, true)
            .RuleFor(o => o.Validation, false)
            .RuleFor(o => o.Suspended, false)
            .RuleFor(o => o.PhoneNumberConfirmed, true)
            .RuleFor(o => o.PasswordHash, f => new PasswordHasher<Account>().HashPassword(null, "Artisashop@2022"));
        var users = userFaker.Generate(99);
        var consumerFaker = new Faker<Account>()
            .RuleFor(o => o.Id, f => "2")
            .RuleFor(o => o.UserName, f => "jane.consumer@artisashop.fr")
            .RuleFor(o => o.Email, (f, o) => o.UserName)
            .RuleFor(o => o.Firstname, f => "john")
            .RuleFor(o => o.Lastname, f => "artisan")
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.Biography, f => f.Lorem.Paragraph())
            .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Job, f => f.Name.JobTitle())
            .RuleFor(o => o.EmailConfirmed, true)
            .RuleFor(o => o.Validation, false)
            .RuleFor(o => o.Suspended, false)
            .RuleFor(o => o.PhoneNumberConfirmed, true)
            .RuleFor(o => o.PasswordHash, f => new PasswordHasher<Account>().HashPassword(null, "Artisashop@2022"));
        users.Add(consumerFaker.Generate(1).First());
        var sellerFaker = new Faker<Account>()
            .RuleFor(o => o.Id, f => "1")
            .RuleFor(o => o.UserName, f => "john.artisan@artisashop.fr")
            .RuleFor(o => o.Email, (f, o) => o.UserName)
            .RuleFor(o => o.Firstname, f => "john")
            .RuleFor(o => o.Lastname, f => "artisan")
            .RuleFor(o => o.Address, f => f.Address.FullAddress())
            .RuleFor(o => o.Biography, f => f.Lorem.Paragraph())
            .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Job, f => f.Name.JobTitle())
            .RuleFor(o => o.EmailConfirmed, true)
            .RuleFor(o => o.Validation, false)
            .RuleFor(o => o.Suspended, false)
            .RuleFor(o => o.PhoneNumberConfirmed, true)
            .RuleFor(o => o.PasswordHash, f => new PasswordHasher<Account>().HashPassword(null, "Artisashop@2022"));
        users.Add(sellerFaker.Generate(1).First());

        // Formats the account's data and adds it to the database
        foreach (var account in users)
        {
            var password = new PasswordHasher<Account>();
            var hashed = password.HashPassword(account, "Artisashop@2022");
            account.PasswordHash = hashed;

            var userStore = new UserStore<Account>(dbContext);
            await userStore.CreateAsync(account);
            if (account.UserName != "john.artisan@artisashop.fr")
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

        var sellers = dbContext.Users.Where(user => user.Email != "jane.consumer@artisashop.fr" &&
            user.Email != "john.artisan@artisashop.fr").Take(9).ToList();

        sellers.Add(dbContext.Users.First(user => user.Email == "john.artisan@artisashop.fr"));
        int i = 0;
        foreach (var account in sellers)
        {
            await AssignRoles(scope.ServiceProvider, account.Id, new[] { Roles.Seller });
            account.Address = DemoAddress[i].Key;
            account.AddressGPS = DemoAddress[i].Value;
            ++i;
            dbContext.Users.Update(account);
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
            .RuleFor(o => o.ProductStyles, f => f.Make(3, () => new ProductStyle(f.Commerce.ProductAdjective())))
            ;

        var demoProducts = Seeder.DemoProductNames
            .Select(pair =>
            {
                var product = productsFaker.Generate();
                product.Name = pair.Key;
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage
                    {
                        Name = pair.Key,
                        ImagePath = pair.Value,
                        Content = null,
                    },
                };
                return product;
            });

        dbContext.Products.AddRange(demoProducts);
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

    public static readonly KeyValuePair<string, string>[] DemoProductNames =
    {
        new("Acanthes", "acanthes.JPG"),
        new("Applique en papier", "applique-en-papier.png"),
        new("Applique en papiper", "applique-en-papiper-contrepartie.JPG"),
        new("Appliques", "appliques.JPG"),
        new("Ballerines en papier 2", "ballerines-en-papier-2.JPG"),
        new("Ballerines en papier", "ballerines-en-papier.JPG"),
        new("Bonheur du jour", "bonheur-du-jour.jpeg"),
        new("Buffet", "buffet.jpeg"),
        new("Buste romain", "buste-romain.JPG"),
        new("Buste siamois", "buste-siamois.png"),
        new("Chandelier en bol", "chandelier-en-bol.JPG"),
        new("Chandelier en fer", "chandelier-en-fer.jpg"),
        new("Chandelier", "chandelier.jpg"),
        new("Chapiteau corinthien", "chapiteau-corinthien.JPG"),
        new("Echassier fantastique", "echassier-fantastique.JPG"),
        new("Echassier", "echassier.JPG"),
        new("Maquette d'église", "maquette-d-eglise.jpeg"),
        new("Médaillon", "medaillon.JPG"),
        new("Natalité AU JAPON", "natalite-jp.JPG"),
        new("Oeuf d'extérieur", "oeuf-d-exterieur.png"),
        new("Oeuf d'intérieur", "oeuf-d-interieur.jpg"),
        new("Support de pierre", "support-de-pierre.jpeg"),
        new("Table à thé", "table à thé.jpg"),
        new("Table a jeux", "table-a-jeux.jpeg"),
        new("Tableau natalité", "tableau-natalite.jpg"),
        new("Tableau raiponse", "tableau-raiponse.jpg"),
        new("Tabouret de piano", "tabouret-de-piano.jpeg"),
    };

    public static readonly KeyValuePair<string, GPSCoord>[] DemoAddress =
    {
        new("48 rue de la course, 67000 Strasbourg", new(48.5827813, 7.7338364)),
        new("41B Rue d'Ostheim, 68320 Jebsheim, France", new(48.1289355, 7.4728017)),
        new("13 Rue d'Oslo, 67210 Obernai, France", new(48.4645601, 7.4693943)),
        new("4Eiffel Tower, 5 Avenue Anatole France, 75007 Paris, France", new(48.8582602, 2.2944991)),
        new("Le Jules Verne, Avenue Gustave Eiffel, 75007 Paris, France", new(48.8581328, 2.2944968)),
        new("Tour Eiffel, Quai Jacques Chirac, 75007 Paris, France", new(48.8592402, 2.2939419)),
        new("4 Rue Vauban, 68000 Colmar, France", new(48.07792, 7.3610782)),
        new("4 Rue Vauban, 68600 Neuf-Brisach, France", new(48.017651, 7.5304749)),
        new("4 Rue Vauban, 68600 Dessenheim, France", new(47.980451, 7.485044)),
        new("4 Rue Vauban, 68320 Muntzenheim, France", new(48.1024371, 7.4695845))
    };

    public static readonly string[] DemoJob =
    {
        new("Ebeniste"),
        new("Sculpteur"),
        new("Tourneur"),
        new("Marqueteur"),
        new("Verrier"),
        new("Souffleur de verre"),
        new("Forgeron"),
        new("Ferronnier"),
        new("Remouleur"),
        new("Menuisier"),
        new("Tapissier"),
        new("Couturier"),
        new("Tailleur"),
        new("Tailleur de pierre")
    };
}

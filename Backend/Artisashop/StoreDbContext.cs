namespace Artisashop;

using Artisashop.Models;
using Artisashop.Models.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class StoreDbContext : IdentityDbContext<Account>
{
    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public StoreDbContext()
    {
    }

    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<BasketItem> Baskets { get; set; } = null!;
    public virtual DbSet<Bill> Bills { get; set; } = null!;
    public virtual DbSet<ChatMessage> ChatMessages { get; set; } = null!;
    public virtual DbSet<Style> Styles { get; set; } = null!;
    public virtual DbSet<Complaint> Complaints { get; set; } = null!;
    public virtual DbSet<ProductStyle> ProductStyles { get; set; } = null!;
    public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // User for model creation through interface
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(ICreatedAt).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType)
                    .Property<DateTime?>(nameof(ICreatedAt.CreatedAt))
                    .ValueGeneratedOnAdd();
            }

            if (typeof(IUpdatedAt).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType)
                    .Property<DateTime?>(nameof(IUpdatedAt.UpdatedAt))
                    .ValueGeneratedOnUpdate();
            }
        }

        builder.Entity<Product>()
            .HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasMany(p => p.Styles)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
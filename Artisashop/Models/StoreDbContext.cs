using Artisashop.Models.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Models
{
    public class StoreDbContext : IdentityDbContext<Account>
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public StoreDbContext()
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Basket> Baskets { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        public virtual DbSet<Style> Styles { get; set; } = null!;

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
        }
    }
}

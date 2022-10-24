using Backend.Models.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class StoreDbContext : IdentityDbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public StoreDbContext()
        {
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Basket>? Baskets { get; set; }
        public DbSet<Bill>? Bills { get; set; }
        public DbSet<ChatMessage>? ChatMessages { get; set; }
        public DbSet<Style>? Styles { get; set; }

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

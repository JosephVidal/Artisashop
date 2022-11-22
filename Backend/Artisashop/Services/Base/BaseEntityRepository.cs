namespace Artisashop.Services.Base;

using Microsoft.EntityFrameworkCore;

public class BaseEntityRepository<TEntity>
    where TEntity : class
{
    protected StoreDbContext DbContext { get; set; }

    protected DbSet<TEntity> DbSet { get; set; }


    protected BaseEntityRepository(StoreDbContext dbContext, DbSet<TEntity> dbSet)
    {
        this.DbContext = dbContext;
        this.DbSet = dbSet;
    }
}
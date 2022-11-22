namespace Artisashop.Services.Base;

using System.Linq.Expressions;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models.Interface;

public abstract class BaseReadOnlyRepository<TEntity, TKey> : BaseEntityRepository<TEntity>,
    IReadRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    protected BaseReadOnlyRepository(StoreDbContext dbContext, DbSet<TEntity> dbSet) : base(dbContext, dbSet)
    {
    }


    public virtual async Task<TEntity?> GetAsync(TKey id)
    {
        return await this.DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public virtual async Task<List<TEntity>> GetListAsync()
    {
        return await this.DbSet.ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await this.DbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetListAsync<TOrderBy>(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TOrderBy>> orderBy, bool ascending = true)
    {
        return ascending
            ? await this.DbSet.Where(predicate).OrderBy(orderBy).ToListAsync()
            : await this.DbSet.Where(predicate).OrderByDescending(orderBy).ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetListAsync<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy,
        bool ascending = true)
    {
        return ascending
            ? await this.DbSet.OrderBy(orderBy).ToListAsync()
            : await this.DbSet.OrderByDescending(orderBy).ToListAsync();
    }
}
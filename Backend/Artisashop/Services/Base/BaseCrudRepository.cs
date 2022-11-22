namespace Artisashop.Services.Base;

using Exceptions;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models.Interface;

/// <summary>
/// Base class for base CRUD services.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKey"></typeparam>
public abstract class BaseCrudRepository<TEntity, TKey> : BaseReadOnlyRepository<TEntity, TKey>,
    ICrudRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    protected BaseCrudRepository(StoreDbContext dbContext, DbSet<TEntity> dbSet) : base(dbContext, dbSet)
    {
    }


    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        return (await this.DbSet.AddAsync(entity)).Entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        return (await this.DbSet.AddAsync(entity)).Entity;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        this.DbSet.Remove(entity);
        await this.DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TKey id)
    {
        var e = await GetAsync(id);
        if (e == null)
        {
            throw new ArtisashopException("Cannot remove entity. Entity not found.");
        }

        await this.DeleteAsync(e);
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        this.DbSet.RemoveRange(entities);
        await this.DbContext.SaveChangesAsync();
    }
}
namespace Artisashop.Services.Base;

using Exceptions;
using Microsoft.EntityFrameworkCore;
using Models.Interface;

/// <summary>
/// Base class for all CRUD services.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKey"></typeparam>
public class CrudRepository<TEntity, TFilterExpression, TKey> : ICrudRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    protected StoreDbContext DbContext { get; set; }

    protected DbSet<TEntity> DbSet { get; set; }


    public CrudRepository(StoreDbContext dbContext, DbSet<TEntity> dbSet)
    {
        DbContext = dbContext;
        DbSet = dbSet;
    }

    public async Task<TEntity?> GetAsync(TKey id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        return (await DbSet.AddAsync(entity)).Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        return (await DbSet.AddAsync(entity)).Entity;
    }

    public Task RemoveAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(TKey id)
    {
        var e = await GetAsync(id);
        if (e == null)
        {
            throw new ArtisashopException("Cannot remove entity. Entity not found.");
        }

        await RemoveAsync(e);
    }

    public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }
}
namespace Artisashop.Common;

using Models.Interface;

/// <summary>
/// CRUD But only the obvious ones.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKey"></typeparam>
public interface IStrictCrudService<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task<TEntity> GetAsync(int id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<TEntity> RemoveAsync(TKey id);
    public Task<TEntity> RemoveAsync(TEntity entity);
    public Task<TEntity> RemoveRangeAsync(IEnumerable<TKey> id);
    public Task<TEntity> RemoveRangeAsync(IEnumerable<TEntity> entities);
}
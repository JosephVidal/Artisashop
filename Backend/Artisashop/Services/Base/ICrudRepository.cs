namespace Artisashop.Services.Base;

using Models.Interface;

public interface ICrudRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task<TEntity?> GetAsync(TKey id);
    public Task<List<TEntity>> GetAllAsync();
    public Task<TEntity> CreateAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task RemoveAsync(TEntity entity);
    public Task RemoveAsync(TKey id);
    public Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}
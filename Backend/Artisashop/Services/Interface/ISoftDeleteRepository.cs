namespace Artisashop.Services.Interface;

using Artisashop.Models.Interface;

public interface ISoftDeleteRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>, ISoftDelete
{
    public Task SoftDeleteAsync(TEntity entity);
    public Task SoftDeleteAsync(TKey id);
    public Task SoftDeleteRangeAsync(IEnumerable<TEntity> entities);
    public Task RestoreDeletedAsync(TEntity entity);
    public Task RestoreDeletedAsync(TKey id);
    public Task RestoreDeletedRangeAsync(IEnumerable<TEntity> entities);
}
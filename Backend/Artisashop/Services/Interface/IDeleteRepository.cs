namespace Artisashop.Services.Interface;

using Artisashop.Models.Interface;

public interface IDeleteRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task DeleteAsync(TEntity entity);
    public Task DeleteAsync(TKey id);
    public Task DeleteRangeAsync(IEnumerable<TEntity> entities);
}
namespace Artisashop.Services.Interface;

using Artisashop.Models.Interface;

public interface IUpdateRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task<TEntity> UpdateAsync(TEntity entity);
}
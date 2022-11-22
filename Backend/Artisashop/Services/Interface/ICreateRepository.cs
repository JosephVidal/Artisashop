namespace Artisashop.Services.Interface;

using Artisashop.Models.Interface;

public interface ICreateRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task<TEntity> CreateAsync(TEntity entity);
}
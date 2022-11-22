namespace Artisashop.Services.Interface;

using Artisashop.Models.Interface;

/// <summary>
/// The base 4 things a CRUD repository should do.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKey"></typeparam>
public interface ICrudRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>,
    ICreateRepository<TEntity, TKey>,
    IUpdateRepository<TEntity, TKey>,
    IDeleteRepository<TEntity, TKey>
    where TEntity : class, IIdentifiable<TKey>
    where TKey : IEquatable<TKey>
{
}

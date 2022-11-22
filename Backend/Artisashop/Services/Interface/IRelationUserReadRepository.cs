namespace Artisashop.Services.Interface;

using Artisashop.Models.Interface;

public interface IRelationUserReadRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>, IRelationUser
{
    public IQueryable<TEntity> GetByUser(string userId);
}
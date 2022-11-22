namespace Artisashop.Services.Interface;

using System.Linq.Expressions;
using Artisashop.Models.Interface;

public interface IReadRepository<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task<TEntity?> GetAsync(TKey id);

    Task<List<TEntity>> GetListAsync();

    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> GetListAsync<TOrderBy>(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TOrderBy>> orderBy, bool ascending = true);

    Task<List<TEntity>> GetListAsync<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, bool ascending = true);
}
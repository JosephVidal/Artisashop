namespace Artisashop.Common;

using Models.Interface;

public interface ICrudService<TEntity, TKey, TListFilter> : IStrictCrudService<TEntity, TKey>
    where TKey : IEquatable<TKey>
    where TEntity : class, IIdentifiable<TKey>
{
    public Task<IEnumerable<TEntity>> GetListAsync(TListFilter filter);
}
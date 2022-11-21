namespace Artisashop.Extensions;

using System;
using System.Linq;
using System.Linq.Expressions;
using Models;
using Models.Interface;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> WithId<TEntity, TKey>(this IQueryable<TEntity> query, TKey id)
        where TKey : IEquatable<TKey>
        where TEntity : class, IIdentifiable<TKey>
    {
        Func<TEntity, bool> func = (TEntity entity) => entity.Id.Equals(id);
        Expression<Func<TEntity, bool>> expression =
            Expression.Lambda<Func<TEntity, bool>>(Expression.Call(func.Method));
        IQueryable<TEntity> ret = query.Where(expression);
        return ret;
    }

    public static IQueryable<Product> Search(this IQueryable<Product> query, string search)
    {
        if (search.Length == 0)
        {
            return query;
        }

        return query.Where(p =>
            (p.Name != null && p.Name.Contains(search))
            || (p.Description != null && p.Description.Contains(search))
            || (p.Styles != null &&
                p.Styles.Any(x => x.Style != null && x.Style.Name != null && x.Style.Name.Contains(search)))
            || (p.Craftsman != null && p.Craftsman.Firstname != null && p.Craftsman.Firstname.Contains(search)));
    }

    public static IQueryable<Account> Search(this IQueryable<Account> query, string search)
    {
        if (search.Length == 0)
        {
            return query;
        }

        return query.Where(p =>
            (p.Firstname != null && p.Firstname.Contains(search))
            || (p.Lastname != null && p.Lastname.Contains(search))
            || (p.Job != null && p.Job.Contains(search)));
    }
}
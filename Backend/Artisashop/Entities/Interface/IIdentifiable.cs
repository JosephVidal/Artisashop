namespace Artisashop.Models.Interface;

using System;

public interface IIdentifiable<TKey>
where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}
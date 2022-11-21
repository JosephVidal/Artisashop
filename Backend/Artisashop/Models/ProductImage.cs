﻿namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Interface;

public class ProductImage : IIdentifiable<int>, ICreatedAt
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    [Required] public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }
}
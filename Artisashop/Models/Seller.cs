using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Interface;

namespace Artisashop.Models;

/// <summary>
/// Seller informations.
/// The seller is attached to a user account.
/// </summary>
public class Seller : IIdentifiable, ICreatedAt, IUpdatedAt
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? StoreName { get; set; }

    /// <summary>
    /// Account of the owner.
    /// </summary>
    public virtual Account? Account { get; set; }

    public string AccountId { get; set; } = null!;

    public virtual List<Product>? Products { get; set; }
}
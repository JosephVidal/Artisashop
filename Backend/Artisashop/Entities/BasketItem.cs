namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums;
using Interface;

public class BasketItem : IIdentifiable<int>, ICreatedAt
{
    [Key] public int Id { get; set; }

    public required string? AccountId { get; set; }

    public required Account? Account { get; set; }

    public required int ProductId { get; set; }

    public required Product? Product { get; set; }

    public required int Quantity { get; set; }

    public required DeliveryOption DeliveryOpt { get; set; }

    public required DeliveryState CurrentState { get; set; }

    public virtual List<BasketPossibleState>? PossibleStates { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? CreatedAt { get; set; }
}
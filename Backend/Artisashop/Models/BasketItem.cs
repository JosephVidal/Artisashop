namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums;
using Interface;

public class BasketItem : IIdentifiable<int>, ICreatedAt
{
    [Key] public int Id { get; set; }

    [Required] public string? AccountId { get; set; }

    [Required] public Account? Account { get; set; }

    [Required] public int ProductId { get; set; }

    [Required] public Product? Product { get; set; }

    [Required] public int Quantity { get; set; }

    [Required] public DeliveryOption DeliveryOpt { get; set; }

    [Required] public DeliveryState CurrentState { get; set; }

    public virtual List<BasketPossibleState>? PossibleStates { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? CreatedAt { get; set; }
}
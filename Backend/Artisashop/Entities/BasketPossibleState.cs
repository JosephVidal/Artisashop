using Artisashop.Models.Enums;

namespace Artisashop.Models;

public class BasketPossibleState
{
    public int Id { get; set; }

    public int BasketId { get; set; }
    public virtual BasketItem? Basket { get; set; }
    
    public DeliveryState DeliveryState { get; set; }
}
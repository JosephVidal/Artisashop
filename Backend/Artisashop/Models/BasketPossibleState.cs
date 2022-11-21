using Artisashop.Models.Enum;

namespace Artisashop.Models;

public class BasketPossibleState
{
    public int Id { get; set; }

    public int BasketId { get; set; }
    public virtual Basket? Basket { get; set; }
    
    public DeliveryState DeliveryState { get; set; }
}
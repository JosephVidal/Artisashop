using Artisashop.Models.Enums;

namespace Artisashop.Models.ViewModel
{
    public class OrderList
    {
        public OrderList(BasketItem item, List<DeliveryState> possibleState)
        {
            Item = item;
            PossibleState = possibleState;
        }

        public BasketItem Item { get; set; }
        public List<DeliveryState> PossibleState { get; set; }
    }
}
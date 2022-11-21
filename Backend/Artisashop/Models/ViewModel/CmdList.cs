using Artisashop.Models.Enum;

namespace Artisashop.Models.ViewModel
{
    public class OrderList
    {
        public OrderList(Basket item, List<DeliveryState> possibleState)
        {
            Item = item;
            PossibleState = possibleState;
        }

        public Basket Item { get; set; }
        public List<DeliveryState> PossibleState { get; set; }
    }
}
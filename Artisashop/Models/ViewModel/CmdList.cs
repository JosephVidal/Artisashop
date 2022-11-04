namespace Artisashop.Models.ViewModel
{
    public class OrderList
    {
        public OrderList(Basket item, List<Basket.State> possibleState)
        {
            Item = item;
            PossibleState = possibleState;
        }

        public Basket Item { get; set; }
        public List<Basket.State> PossibleState { get; set; }
    }
}
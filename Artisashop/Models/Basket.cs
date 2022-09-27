using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artisashop.Models
{
    public class Basket
    {
        protected Basket()
        {
        }

        public Basket(Account account, Product product, int quantity, DeliveryOption deliveryOpt, State currentState, List<State> possibleState)
        {
            AccountId = account!.Id;
            Account = account;
            ProductId = product!.Id;
            Product = product;
            Quantity = quantity;
            DeliveryOpt = deliveryOpt;
            CurrentState = currentState;
            PossibleState = possibleState;
        }

        [Key]
        public int Id { get; set; }
        public string? AccountId { get; set; }
        public Account? Account { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public DeliveryOption DeliveryOpt { get; set; }
        public State CurrentState { get; set; }
        [NotMapped]
        public List<State>? PossibleState { get; set; }

        public static string StateToStr(State state)
        {
            return state switch
            {
                State.WAITINGCRAFTSMAN => "En attente de l'artisan",
                State.WAITINGCONSUMER => "En attente du consommateur",
                State.REFUSED => "Refuser",
                State.VALIDATED => "Valider",
                State.ONGOING => "En cours",
                State.DELIVERY => "En livraison",
                State.END => "Finis",
                _ => "N/A",
            };
        }
        public enum State
        {
            WAITINGCRAFTSMAN = 0,
            WAITINGCONSUMER = 1,
            REFUSED = 2,
            VALIDATED = 3,
            ONGOING = 4,
            DELIVERY = 5,
            END = 6
        }
        public enum DeliveryOption
        {
            DELIVERY = 0,
            TAKEOUT = 1
        }
    }
}

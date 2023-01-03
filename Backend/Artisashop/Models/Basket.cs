using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Artisashop.Models
{
    public class Basket
    {
        public Basket()
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
        [Required]
        public string? AccountId { get; set; }
        [Required]
        public Account? Account { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public Product? Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DeliveryOption DeliveryOpt { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
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
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum State
        {
            WAITINGCONSUMER = 0,
            WAITINGCRAFTSMAN = 1,
            REFUSED = 2,
            VALIDATED = 3,
            ONGOING = 4,
            DELIVERY = 5,
            END = 6
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum DeliveryOption
        {
            DELIVERY = 0,
            TAKEOUT = 1
        }
    }
}

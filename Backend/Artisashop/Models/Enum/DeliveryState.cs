namespace Artisashop.Models.Enum;

using System.ComponentModel;

public enum DeliveryState
{
    [Description("En attente de l'artisan")]
    WAITINGCRAFTSMAN = 0,

    [Description("En attente du consommateur")]
    WAITINGCONSUMER = 1,

    [Description("Refusée")] REFUSED = 2,

    [Description("Validée")] VALIDATED = 3,

    [Description("En cours")] ONGOING = 4,

    [Description("En livraison")] DELIVERY = 5,

    [Description("Finis")] END = 6,

    [Description("N/A")] OTHER = -1,
}
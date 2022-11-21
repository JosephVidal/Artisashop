namespace Artisashop.Helpers;

using Models.Enums;

public static class NextDeliveryStates
{
    
    /// <summary>
    /// Generating possible command state regading its actual state
    /// </summary>
    /// <param name="state">The actual command state</param>
    /// <param name="delOpt">Delivery option choosen</param>
    /// <returns>List of state possible</returns>
    public static List<DeliveryState> GetNextDeliveryStates(DeliveryState state, DeliveryOption delOpt)
    {
        return (state, delOpt) switch
        {
            (DeliveryState.WAITINGCRAFTSMAN, _) => new() { DeliveryState.REFUSED },
            (DeliveryState.VALIDATED, DeliveryOption.TAKEOUT) => new() { DeliveryState.ONGOING, DeliveryState.DELIVERY, DeliveryState.END },
            (DeliveryState.VALIDATED, DeliveryOption.DELIVERY) => new() { DeliveryState.ONGOING, DeliveryState.END },
            (DeliveryState.ONGOING, DeliveryOption.TAKEOUT) => new() { DeliveryState.DELIVERY, DeliveryState.END },
            (DeliveryState.ONGOING, DeliveryOption.DELIVERY) => new() { DeliveryState.END },
            (DeliveryState.DELIVERY, _) => new() { DeliveryState.END },
            (DeliveryState.WAITINGCONSUMER, _) => new() { },
            (DeliveryState.REFUSED, _) => new() { },
            (DeliveryState.END, _) => new() { },
            _ => new() { }
        };
    }

}
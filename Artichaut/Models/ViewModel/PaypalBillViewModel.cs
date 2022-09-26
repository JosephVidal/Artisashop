using Newtonsoft.Json;

namespace Artichaut.Models.ViewModel
{
    public class PaypalBillViewModel
    {
        [JsonConstructor]
        public PaypalBillViewModel()
        {
            PurchaseUnits = new();
        }

        [JsonProperty("purchase_units")]
        public List<PurchaseUnitElem> PurchaseUnits { get; set; }

        //[JsonArray("purchaseUnitElem")]
        public class PurchaseUnitElem
        {
            [JsonConstructor]
            public PurchaseUnitElem()
            {
                Amount = new("EUR", 0);
                Items = new();
            }

            [JsonProperty("amount")]
            public Amount Amount { get; set; }
            [JsonProperty("items")]
            public List<ItemElem> Items { get; set; }
        }
        //[JsonArray("amount")]
        public class Amount
        {
            [JsonConstructor]
            public Amount(string currencyCode, double value)
            {
                CurrencyCode = currencyCode;
                Value = value;
                Breakdown = new(currencyCode, value);
            }

            [JsonProperty("currency_code")]
            public string CurrencyCode { get; set; }
            [JsonProperty("value")]
            public double Value { get; set; }
            [JsonProperty("breakdown")]
            public Breakdown Breakdown { get; set; }
        }
        //[JsonArray("itemElem")]
        public class ItemElem
        {
            [JsonConstructor]
            public ItemElem(string name, string? description, int quantity, string currencyCode, double value)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                UnitAmount = new(currencyCode, value);
            }

            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("description")]
            public string? Description { get; set; }
            [JsonProperty("quantity")]
            public int Quantity { get; set; }
            [JsonProperty("unit_amount")]
            public UnitAmount UnitAmount { get; set; }
        }
        //[JsonArray("breakdown")]
        public class Breakdown
        {
            [JsonConstructor]
            public Breakdown(string currencyCode, double value)
            {
                ItemTotal = new(currencyCode, value);
            }

            [JsonProperty("item_total")]
            public UnitAmount ItemTotal { get; set; }
        }
        //[JsonArray("unitAmount")]
        public class UnitAmount
        {
            public UnitAmount(string currencyCode, double value)
            {
                CurrencyCode = currencyCode;
                Value = value;
            }

            [JsonProperty("currency_code")]
            public string CurrencyCode { get; set; }
            [JsonProperty("value")]
            public double Value { get; set; }
        }
    }
}

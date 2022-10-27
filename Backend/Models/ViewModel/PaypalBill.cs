using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models.ViewModel
{
    public class PaypalBill
    {
        //[Newtonsoft.Json.JsonConstructor]
        public PaypalBill()
        {
            PurchaseUnits = new();
        }

        [JsonProperty("purchase_units")]
        [JsonPropertyName("purchase_units")]
        public List<PurchaseUnitElem> PurchaseUnits { get; set; }

        //[JsonArray("purchaseUnitElem")]
        public class PurchaseUnitElem
        {
            //[Newtonsoft.Json.JsonConstructor]
            public PurchaseUnitElem()
            {
                Amount = new("EUR", 0);
                Items = new();
            }

            [Required]
            [JsonProperty("amount")]
            [JsonPropertyName("amount")]
            public Amount? Amount { get; set; }
            [Required]
            [JsonProperty("items")]
            [JsonPropertyName("items")]
            public List<ItemElem>? Items { get; set; }
        }

        //[JsonArray("amount")]
        public class Amount
        {
            //[Newtonsoft.Json.JsonConstructor]
            public Amount()
            {
            }
            public Amount(string currencyCode, double value)
            {
                CurrencyCode = currencyCode;
                Value = value;
                Breakdown = new(currencyCode, value);
            }

            [Required]
            [JsonProperty("currency_code")]
            [JsonPropertyName("currency_code")]
            public string? CurrencyCode { get; set; }
            [Required]
            [JsonProperty("value")]
            [JsonPropertyName("value")]
            public double? Value { get; set; }
            [Required]
            [JsonProperty("breakdown")]
            [JsonPropertyName("breakdown")]
            public Breakdown? Breakdown { get; set; }
        }

        //[JsonArray("itemElem")]
        public class ItemElem
        {
            //[Newtonsoft.Json.JsonConstructor]
            public ItemElem()
            {
            }
            public ItemElem(string name, string? description, int quantity, string currencyCode, double value)
            {
                Name = name;
                Description = description;
                Quantity = quantity;
                UnitAmount = new(currencyCode, value);
            }

            [Required]
            [JsonProperty("name")]
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonProperty("description")]
            [JsonPropertyName("description")]
            public string? Description { get; set; }
            [Required]
            [JsonProperty("quantity")]
            [JsonPropertyName("quantity")]
            public int? Quantity { get; set; }
            [Required]
            [JsonProperty("unit_amount")]
            [JsonPropertyName("unit_amount")]
            public UnitAmount? UnitAmount { get; set; }
        }
        //[JsonArray("breakdown")]
        public class Breakdown
        {
            //[Newtonsoft.Json.JsonConstructor]
            public Breakdown()
            {
            }

            public Breakdown(string currencyCode, double value)
            {
                ItemTotal = new(currencyCode, value);
            }

            [Required]
            [JsonProperty("item_total")]
            [JsonPropertyName("item_total")]
            public UnitAmount? ItemTotal { get; set; }
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
            [JsonPropertyName("currency_code")]
            public string CurrencyCode { get; set; }
            [JsonProperty("value")]
            [JsonPropertyName("value")]
            public double Value { get; set; }
        }
    }
}

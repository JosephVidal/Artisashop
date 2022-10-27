using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.ViewModel
{
    public class PaypalBill
    {
        public PaypalBill()
        {
            PurchaseUnits = new();
        }

        public List<PurchaseUnitElem> PurchaseUnits { get; set; }

        public class PurchaseUnitElem
        {
            public PurchaseUnitElem()
            {
                Amount = new("EUR", 0);
                Items = new();
            }

            [Required]
            public Amount? Amount { get; set; }
            [Required]
            public List<ItemElem>? Items { get; set; }
        }

        public class Amount
        {
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
            public string? CurrencyCode { get; set; }
            [Required]
            public double? Value { get; set; }
            [Required]
            public Breakdown? Breakdown { get; set; }
        }

        public class ItemElem
        {
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
            public string? Name { get; set; }
            public string? Description { get; set; }
            [Required]
            public int? Quantity { get; set; }
            [Required]
            public UnitAmount? UnitAmount { get; set; }
        }
        //[JsonArray("breakdown")]
        public class Breakdown
        {
            public Breakdown()
            {
            }

            public Breakdown(string currencyCode, double value)
            {
                ItemTotal = new(currencyCode, value);
            }

            [Required]
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

            public string CurrencyCode { get; set; }
            public double Value { get; set; }
        }
    }
}

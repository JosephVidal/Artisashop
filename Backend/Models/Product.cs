﻿using Backend.Models.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Backend.Models
{
    public class Product
    {
        public Product()
        {
            ImagesList = "[]";
            Images = new List<string>();
            StylesList = "[]";
            Styles = new List<string>();
        }

        public Product(string name, Account craftsman, double? price = null, string? description = null, int quantity = 1, List<string>? images = null, List<string>? style = null)
        {
            Name = name;
            Price = price;
            Description = description;
            Quantity = quantity;
            CraftsmanId = craftsman.Id;
            Craftsman = craftsman;
            ImagesList = JsonSerializer.Serialize(images);
            StylesList = JsonSerializer.Serialize(style);
        }

        public Product(CreateProduct product, Account craftsman)
        {
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
            Quantity = product.Quantity;
            CraftsmanId = craftsman.Id;
            Craftsman = craftsman;
            ImagesList = JsonSerializer.Serialize(product.Images);
            StylesList = JsonSerializer.Serialize(product.Styles);
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? CraftsmanId { get; set; }
        [Required]
        public Account? Craftsman { get; set; }
        public string ImagesList { get; set; }
        [NotMapped]
        public List<string>? Images
        {
            get => JsonSerializer.Deserialize<List<string>>(ImagesList);
            set => ImagesList = JsonSerializer.Serialize(Images);
        }
        public string StylesList { get; set; }
        [NotMapped]
        public List<string>? Styles
        {
            get => JsonSerializer.Deserialize<List<string>>(StylesList);
            set => StylesList = JsonSerializer.Serialize(Styles);
        }
    }
}

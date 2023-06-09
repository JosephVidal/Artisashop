﻿using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models.ViewModel
{
    public class CreateProduct
    {
        public CreateProduct()
        {
            Images = new List<string>();
            Styles = new List<string>();
        }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public List<string> Images { get; set; }
        public List<string> Styles { get; set; }
    }
}

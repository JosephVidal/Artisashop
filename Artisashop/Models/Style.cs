﻿using System.ComponentModel.DataAnnotations;

namespace Artisashop.Models
{
    public class Style
    {


        public Style(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
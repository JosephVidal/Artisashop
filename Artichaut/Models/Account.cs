﻿using Artichaut.Models.Interface;
using Artichaut.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artichaut.Models
{
    public class Account : IdentityUser<string>, ICreatedAt, IUpdatedAt
    {
        public Account()
        {
        }

        public Account(Register model)
        {
            UserName = model.Email;
            Email = model.Email;
            Lastname = model.Lastname;
            Firstname = model.Firstname;
            Role = model.Role;
            Job = model.Job;
            Bills = new List<Bill>();
            Products = new List<Product>();
        }

        public Account(string lastname, string firstname, UserType role, string job)
        {
            Lastname = lastname;
            Firstname = firstname;
            Role = role;
            Job = job;
            Bills = new List<Bill>();
            Products = new List<Product>();
        }

        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public UserType Role { get; set; }
        [Required]
        [PasswordPropertyText]
        [NotMapped]
        public string? Password { get; set; }
        public string? Job { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }
        public List<Product>? Products { get; set; }
        public Basket? Basket { get; set; }
        public List<Bill>? Bills { get; set; }
        public enum UserType
        {
            NONE = -1,
            CONSUMER = 0,
            CRAFTSMAN = 1,
            PARTNER = 2,
            ADMIN = 3
        }
    }
}

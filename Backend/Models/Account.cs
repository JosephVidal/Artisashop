using Backend.Models.Interface;
using Backend.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
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
            Baskets = new List<Basket>();
        }

        public Account(string username, string email, string lastname, string firstname, UserType role, string job)
        {
            UserName = username;
            Email = email;
            Lastname = lastname;
            Firstname = firstname;
            Role = role;
            Job = job;
            Bills = new List<Bill>();
            Products = new List<Product>();
            Baskets = new List<Basket>();
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
        public List<Basket>? Baskets { get; set; }
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

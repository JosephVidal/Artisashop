using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artisashop.Models.Interface;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Artisashop.Models;

public class Account : IdentityUser, ICreatedAt, IUpdatedAt
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
        Job = model.Job;
        Bills = new List<Bill>();
        Baskets = new List<Basket>();
    }

    public Account(string username, string email, string lastname, string firstname, string job)
    {
        UserName = username;
        Email = email;
        Lastname = lastname;
        Firstname = firstname;
        Job = job;
        Bills = new List<Bill>();
        Baskets = new List<Basket>();
    }

    [Required] public string? Lastname { get; set; }
    [Required] public string? Firstname { get; set; }

    [Required]
    [PasswordPropertyText]
    [NotMapped]
    public string? Password { get; set; }

    public string? Job { get; set; }
    public string? Address { get; set; }
    public GPSCoord? AddressGPS { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Seller account of the user.
    /// </summary>
    public virtual Seller? Seller { get; set; }
    
    public int? SellerId { get; set; }

    public List<Basket>? Baskets { get; set; }

    public List<Bill>? Bills { get; set; }
}
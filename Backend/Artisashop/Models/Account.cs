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
        Address = model.Address;
        Suspended = false;
        Validation = false;
    }

    [Required] public string? Lastname { get; set; }
    [Required] public string? Firstname { get; set; }
    // TODO: make it more elegant
    public string? ProfilePicture { get; set; }
    public string? Job { get; set; }
    public string? Biography { get; set; }
    public string? Address { get; set; }
    public GPSCoord? AddressGPS { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Basket>? Baskets { get; set; }
    public List<Bill>? Bills { get; set; }
    [Required] public bool? Suspended { get; set; }

    #region Seller

    public List<Product>? Products { get; set; }
    [Required] public bool? Validation { get; set; }

    #endregion
}
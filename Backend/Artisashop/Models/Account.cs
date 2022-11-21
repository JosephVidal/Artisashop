using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artisashop.Models.Interface;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Artisashop.Models;

public class Account : IdentityUser, IIdentifiable<string>, ICreatedAt, IUpdatedAt, ISoftDelete
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
        Baskets = new List<BasketItem>();
        Address = model.Address;
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
    public List<BasketItem>? Baskets { get; set; } = new ();
    public List<Bill>? Bills { get; set; } = new ();
    [Required] public bool? Suspended { get; set; }

    #region Seller

    public List<Product>? Products { get; set; } = new ();
    [Required] public bool? Validation { get; set; }

    #endregion

    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Artisashop.Models.Interface;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Artisashop.Models;

public class Account : IdentityUser, ICreatedAt, IUpdatedAt
{
    [JsonConstructor]
    public Account()
    {
    }


    [Required]
    [ProtectedPersonalData]
    public string? Lastname { get; set; }

    [Required]
    [ProtectedPersonalData]
    public string? Firstname { get; set; }

    // TODO: make it more elegant
    public string? ProfilePicture { get; set; }

    public string? Job { get; set; }

    public string? Biography { get; set; }

    [ProtectedPersonalData]
    public string? Address { get; set; }

    [ProtectedPersonalData]
    public GPSCoord? AddressGPS { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<Basket>? Baskets { get; set; }

    public List<Bill>? Bills { get; set; }

    [Required]
    public bool? Suspended { get; set; }

    #region Seller

    public List<Product>? Products { get; set; }

    [Required] public bool? Validation { get; set; }

    #endregion
}
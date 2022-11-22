using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artisashop.Models.Interface;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Artisashop.Models;

public class Account : IdentityUser, IIdentifiable<string>, ICreatedAt, IUpdatedAt, ISoftDelete
{
    public required string? LastName { get; set; }

    public required string? FirstName { get; set; }
    
    public string? PreferredName { get; set; }

    // TODO: make it more elegant
    public string? ProfilePicture { get; set; }

    public string? Job { get; set; }

    public string? Biography { get; set; }

    public string? Address { get; set; }

    public GpsCoordinates? AddressGps { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual List<BasketItem>? Baskets { get; set; }

    public List<Bill>? Bills { get; set; } = new();

    public bool? Suspended { get; set; }

    public virtual List<Product>? Products { get; set; }

    public bool? Validation { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }
}
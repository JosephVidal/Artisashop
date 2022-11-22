namespace Artisashop.Models.ViewModel;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Artisashop.Models.Account;

public class Register
{
    [EmailAddress]
    public required string? Email { get; set; }
    
    [PasswordPropertyText]
    public required string? Password { get; set; }
    
    public required string? Lastname { get; set; }

    public required string? Firstname { get; set; }
}
namespace Artisashop.Models.ViewModel.Accounts;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Register
{
    [EmailAddress]
    public required string? Email { get; set; }

    [PasswordPropertyText]
    public required string? Password { get; set; }

    public required string? LastName { get; set; }

    public required string? FirstName { get; set; }
}
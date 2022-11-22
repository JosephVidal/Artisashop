namespace Artisashop.Models.ViewModel.Accounts;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Login
{
    [EmailAddress]
    public required string Email { get; set; }

    [PasswordPropertyText]
    public required string Password { get; set; }
}
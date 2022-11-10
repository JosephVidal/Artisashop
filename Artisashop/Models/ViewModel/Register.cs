using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Artisashop.Models.Account;

namespace Artisashop.Models.ViewModel;

public class Register
{
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }
    [Required]
    public string? Lastname { get; set; }
    [Required]
    public string? Firstname { get; set; }
    public string? Job { get; set; }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Artichaut.Models.Account;

namespace Artichaut.Models.ViewModel;

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
    [Required]
    public UserType Role { get; set; }
    public string? Job { get; set; }
}
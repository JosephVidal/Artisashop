namespace Artisashop.Models.ViewModel;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Register
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }

    [Required]
    public string? Lastname { get; set; }

    [Required]
    public string? Firstname { get; set; }

    [Required]
    public string? Role { get; set; }

    public string? Job { get; set; }

    public string? Address { get; set; }
}
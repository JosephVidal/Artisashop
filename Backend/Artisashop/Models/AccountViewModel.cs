namespace Artisashop.Models;

public class AccountViewModel
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public bool? TwoFactorEnabled { get; set; }

    public string? ProfilePicture { get; set; }
    
    public List<string> Roles { get; set; } = new List<string>();
}
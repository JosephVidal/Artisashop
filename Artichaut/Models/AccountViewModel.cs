namespace Artichaut.Models;

public class AccountViewModel
{
    public AccountViewModel()
    {
    }

    public AccountViewModel(Account appUser)
    {
        Username = appUser.UserName;
        Email = appUser.Email;
        EmailConfirmed = appUser.EmailConfirmed;
        TwoFactorEnabled = appUser.TwoFactorEnabled;
    }

    public AccountViewModel(string username, string email, bool emailConfirmed, bool twoFactorEnabled)
    {
        Username = username;
        Email = email;
        EmailConfirmed = emailConfirmed;
        TwoFactorEnabled = twoFactorEnabled;
    }

    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public bool? TwoFactorEnabled { get; set; }
}
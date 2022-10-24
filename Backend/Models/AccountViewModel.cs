namespace Backend.Models;

public class AccountViewModel
{
    public AccountViewModel()
    {
    }

    public AccountViewModel(Account appUser)
    {
        Id = appUser.Id;
        Username = appUser.UserName;
        Email = appUser.Email;
        EmailConfirmed = appUser.EmailConfirmed;
        TwoFactorEnabled = appUser.TwoFactorEnabled;
    }

    public AccountViewModel(string id, string username, string email, bool emailConfirmed, bool twoFactorEnabled)
    {
        Id = id;
        Username = username;
        Email = email;
        EmailConfirmed = emailConfirmed;
        TwoFactorEnabled = twoFactorEnabled;
    }

    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public bool? TwoFactorEnabled { get; set; }
}
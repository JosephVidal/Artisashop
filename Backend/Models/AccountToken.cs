namespace Backend.Models;

public class AccountToken
{
    private AccountToken()
    {
    }

    public AccountToken(AccountViewModel user, string token)
    {
        User = user;
        Token = token;
    }

    public AccountViewModel? User { get; set; }
    public string? Token { get; set; }
}
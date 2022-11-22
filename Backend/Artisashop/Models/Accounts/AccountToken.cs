namespace Artisashop.Models.ViewModel.Accounts;

public class AccountToken
{
    public required AccountViewModel? User { get; set; }

    public required string? Token { get; set; }
}
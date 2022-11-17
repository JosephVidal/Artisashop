namespace Artisashop.Models.ViewModel.Accounts;

public class GetAccountResult
{
    public GetAccountResult(Account account, IList<string> roles)
    {
        Account = account;
        Roles = roles;
    }

    public Account Account { get; set; }

    public IList<string> Roles { get; set; }
}
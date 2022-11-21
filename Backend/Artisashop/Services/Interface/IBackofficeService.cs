namespace Artisashop.Services.Interface;

using Models;

public interface IBackofficeService
{
    public Task ChangeCraftsmanValidationStatusAsync(int craftsmanId, bool isValidated);
    public Task ChangeCraftsmanStatusAsync(int craftsmanId, bool isActive);

    public Task<List<Account>> GetAccountsAsync();
    public Task<Account> GetAccountByIdAsync(string accountId);
    public Task<Account> GetAccountByEmailAsync(string email);
    public Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber);
}
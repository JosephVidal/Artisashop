namespace Artisashop.Services;

using System.Linq.Expressions;
using Base;
using Exceptions;
using Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Interface;

public interface IAccountService<TUser> : IReadRepository<TUser, string>, ISoftDeleteRepository<TUser, string>
    where TUser : IdentityUser, IIdentifiable<string>, ISoftDelete
{
    Task<TUser> GetFromEmailAsync(string email);
    Task<IdentityResult> RegisterAsync(TUser user, string password);
    Task<IdentityResult> SignInAsync(TUser user, bool isPersistent);
    Task<IdentityResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task<IdentityResult> SignOutAsync();
    Task<IdentityResult> UpdateUserAsync(TUser user);
    Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);
    Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);
    Task<string> GeneratePasswordResetTokenAsync(TUser user);
    Task<bool> IsEmailConfirmedAsync(TUser user);
    Task<bool> IsUserInRoleAsync(TUser user, string role);
    Task<bool> CheckLoginAsync(string account, string password);
}

public class AccountService : BaseReadOnlyRepository<Account, string>, IAccountService<Account>
{
    public AccountService(StoreDbContext dbContext) : base(dbContext, dbContext.Users)
    {
    }

    public async Task<List<Account>> GetListAsync<TKey1>(Expression<Func<Account, bool>> predicate,
        Expression<Func<Account, TKey1>> orderBy, bool ascending = true)
    {
        return ascending
            ? await this.DbSet.Where(predicate).OrderBy(orderBy).ToListAsync()
            : await this.DbSet.Where(predicate).OrderByDescending(orderBy).ToListAsync();
    }

    public async Task<List<Account>> GetListAsync<TKey1>(Expression<Func<Account, TKey1>> orderBy,
        bool ascending = true)
    {
        return ascending
            ? await this.DbSet.OrderBy(orderBy).ToListAsync()
            : await this.DbSet.OrderByDescending(orderBy).ToListAsync();
    }

    public async Task SoftDeleteAsync(Account entity)
    {
        this.DbSet.Remove(entity);
        await this.DbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(string id)
    {
        var entity = await this.DbSet.FindAsync(id);
        if (entity == null)
        {
            throw new ArtisashopException("Cannot find the user.");
        }

        this.DbSet.Remove(entity);
        await this.DbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteRangeAsync(IEnumerable<Account> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<Account> GetFromEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> RegisterAsync(Account user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> SignInAsync(Account user, bool isPersistent)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
        bool isPersistent)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> SignOutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> UpdateUserAsync(Account user)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> ChangePasswordAsync(Account user, string currentPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> ResetPasswordAsync(Account user, string token, string newPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GeneratePasswordResetTokenAsync(Account user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsEmailConfirmedAsync(Account user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsUserInRoleAsync(Account user, string role)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckLoginAsync(string account, string password)
    {
        throw new NotImplementedException();
    }
}
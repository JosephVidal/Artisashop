namespace Artisashop.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using Base;
using Configurations;
using Exceptions;
using Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Interface;

public interface IAccountService<TUser> : IReadRepository<TUser, string>, ISoftDeleteRepository<TUser, string>
    where TUser : IdentityUser, IIdentifiable<string>, ISoftDelete
{
    Task SignInAsync(TUser user, bool isPersistent);
    Task SignOutAsync();
    Task<Account?> GetFromEmailAsync(string email);
    Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string expectedXsrf);
    Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);
    Task<IdentityResult> GetExternalLoginInfoAsync2(ExternalLoginInfo externalLoginInfo);
    Task<IdentityResult> RegisterAsync(TUser user, string password);
    Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);
    Task<IdentityResult> UpdateUserAsync(TUser user);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task<SignInResult> SignInWithPasswordAsync(Account user, string password, bool isPersistent);
    Task<bool> CheckLoginAsync(string account, string password);
    Task<bool> IsEmailConfirmedAsync(TUser user);
    Task<bool> IsUserInRoleAsync(TUser user, string role);
    Task<string> GeneratePasswordResetTokenAsync(TUser user);
    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    Task<string> GenerateJwtTokenAsync(TUser user);
    Task<string> GenerateEmailConfirmationTokenAsync(TUser user);
    Task<IdentityResult> ConfirmEmailAsync(TUser user, string token);
    Task<IList<string>> GetRolesAsync(TUser user);
    Task<IdentityResult> AddToRoleAsync(TUser user, string role);
    Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role);
}

public class AccountService : BaseReadOnlyRepository<Account, string>, IAccountService<Account>
{
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signInManager;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly GpsService _gpsService;

    public AccountService(
        StoreDbContext dbContext,
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        JwtConfiguration jwtConfiguration,
        GpsService gpsService)
        : base(dbContext, dbContext.Users)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtConfiguration = jwtConfiguration;
        _gpsService = gpsService;
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
        var ids = entities.Select(x => x.Id).ToList();
        var accounts = await this.DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        foreach (var account in accounts)
        {
            account.IsDeleted = true;
            account.DeletedAt = DateTime.Now;
        }

        await this.DbContext.SaveChangesAsync();
    }

    public async Task RestoreDeletedAsync(Account entity)
    {
        var elem = this.DbSet.Attach(entity);
        var entry = elem.Entity;
        entry.IsDeleted = false;
        entry.DeletedAt = null;
        this.DbSet.Update(entity);
        await this.DbContext.SaveChangesAsync();
    }

    public async Task RestoreDeletedAsync(string id)
    {
        var elem = this.DbSet.FirstOrDefault(x => x.Id == id);
        if (elem == null)
        {
            throw new ArtisashopException("Cannot find the user.");
        }

        elem.IsDeleted = false;
        elem.DeletedAt = null;
        this.DbSet.Update(elem);
        await this.DbContext.SaveChangesAsync();
    }

    public async Task RestoreDeletedRangeAsync(IEnumerable<Account> entities)
    {
        var ids = entities.Select(x => x.Id).ToList();
        var accounts = await this.DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        foreach (var account in accounts)
        {
            account.IsDeleted = false;
            account.DeletedAt = null;
        }

        DbSet.UpdateRange(accounts);
        await this.DbContext.SaveChangesAsync();
    }

    public async Task<Account?> GetFromEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> RegisterAsync(Account user, string password)
    {
        // All users have their email for username
        user.UserName = user.Email;

        // Computes the GPS coordinates of the user
        if (user.Address != null && user.AddressGps == null)
        {
            user.AddressGps = await _gpsService.GetGPSFromAddressAsync(user.Address);
        }

        return await _userManager.CreateAsync(user, password);
    }

    public async Task SignInAsync(Account user, bool isPersistent)
    {
        await _signInManager.SignInAsync(user, isPersistent);
    }

    public async Task<SignInResult> SignInWithPasswordAsync(Account user, string password, bool isPersistent)
    {
        return await _signInManager.PasswordSignInAsync(user, password, isPersistent, false);
    }

    public async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
        bool isPersistent)
    {
        return await _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
    }

    public async Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string expectedXsrf)
    {
        return await _signInManager.GetExternalLoginInfoAsync(expectedXsrf);
    }

    public async Task<IdentityResult> GetExternalLoginInfoAsync2(ExternalLoginInfo externalLoginInfo)
    {
        return await _signInManager.UpdateExternalAuthenticationTokensAsync(externalLoginInfo);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> UpdateUserAsync(Account user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> ChangePasswordAsync(Account user, string currentPassword, string newPassword)
    {
        return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public async Task<IdentityResult> ResetPasswordAsync(Account user, string token, string newPassword)
    {
        return await _userManager.ResetPasswordAsync(user, token, newPassword);
    }

    public async Task<string> GeneratePasswordResetTokenAsync(Account user)
    {
        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
    {
        return await _signInManager.GetExternalAuthenticationSchemesAsync();
    }

    public async Task<string> GenerateJwtTokenAsync(Account user)
    {
        var roles = _userManager.GetRolesAsync(user).Result;

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtConfiguration.Expiration));

        var token = new JwtSecurityToken(
            _jwtConfiguration.Issuer,
            _jwtConfiguration.Audience,
            claims,
            expires: expires,
            signingCredentials: credentials
        );

        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(Account user)
    {
        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task<IdentityResult> ConfirmEmailAsync(Account user, string token)
    {
        return await _userManager.ConfirmEmailAsync(user, token);
    }

    public async Task<IList<string>> GetRolesAsync(Account user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<IdentityResult> AddToRoleAsync(Account user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<IdentityResult> RemoveFromRoleAsync(Account user, string role)
    {
        return await _userManager.RemoveFromRoleAsync(user, role);
    }

    public async Task<bool> IsEmailConfirmedAsync(Account user)
    {
        return await _userManager.IsEmailConfirmedAsync(user);
    }

    public async Task<bool> IsUserInRoleAsync(Account user, string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> CheckLoginAsync(string account, string password)
    {
        var user = await _userManager.FindByNameAsync(account);
        if (user == null)
        {
            throw new ArtisashopException("User not found");
        }

        return await _userManager.CheckPasswordAsync(user, password);
    }
}
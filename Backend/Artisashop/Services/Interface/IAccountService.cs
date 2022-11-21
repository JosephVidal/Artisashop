namespace Artisashop.Services.Interface;

using Microsoft.AspNetCore.Identity;
using Models;

public interface IAccountService<TUser>
    where TUser : IdentityUser
{
    Task<TUser> GetUserAsync(string email);
    Task<IdentityResult> RegisterUserAsync(TUser user, string password);
    Task<IdentityResult> SignInAsync(TUser user, bool isPersistent);
    Task<IdentityResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task<IdentityResult> SignOutAsync();
    Task<IdentityResult> UpdateUserAsync(TUser user);
    Task<IdentityResult> DeleteUserAsync(TUser user);
    Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);
    Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);
    Task<string> GeneratePasswordResetTokenAsync(TUser user);
    Task<bool> IsEmailConfirmedAsync(TUser user);
    Task<bool> IsUserInRoleAsync(TUser user, string role);
    Task<bool> CheckLoginAsync(string account, string password);
}
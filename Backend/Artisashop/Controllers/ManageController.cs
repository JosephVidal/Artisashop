// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Artisashop.Configurations;

namespace Artisashop.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Artisashop.Models;
using Artisashop.Interfaces.IService;
using Artisashop.Models.ViewModel.Manage;

[Authorize]
public class ManageController : Controller
{
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signInManager;
    private readonly IMailService _emailSender;
    private readonly ILogger _logger;


    public ManageController(
    UserManager<Account> userManager,
    SignInManager<Account> signInManager,
    IMailService emailSender,
    ILoggerFactory loggerFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _logger = loggerFactory.CreateLogger<ManageController>();
    }


    //
    // GET: /Manage/Index
    [HttpGet, Route("[controller]", Name = "ManageIndex")]
    public async Task<IActionResult> Index(ManageMessageId? message = null)
    {
        ViewData["StatusMessage"] =
            message == ManageMessageId.ChangePasswordSuccess ? "Votre mot de passe a été modifié."
            : message == ManageMessageId.SetPasswordSuccess ? "Votre mot de passe a été créé."
            : message == ManageMessageId.Error ? "Une erreur est survenue."
            : "";

        var user = await GetCurrentUserAsync();
        var model = new IndexViewModel
        {
            HasPassword = await _userManager.HasPasswordAsync(user),
            Logins = await _userManager.GetLoginsAsync(user),
            BrowserRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user)
        };
        // return View(model);
        return Ok(model);
    }

    //
    // POST: /Manage/RemoveLogin
    [HttpPost, Route("[controller]/RemoveLogin", Name = "RemoveLogin")]
    [ValidateAntiForgeryToken]
    public async Task RemoveLogin(RemoveLoginViewModel account)
    {
        ManageMessageId? message = ManageMessageId.Error;
        var user = await GetCurrentUserAsync();
        if (user != null)
        {
            bool useExternalLogin = User.HasClaim(ClaimTypes.AuthenticationMethod, FranceConnectConfiguration.ProviderScheme);
            var result = await _userManager.RemoveLoginAsync(user, account.LoginProvider, account.ProviderKey);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                if (useExternalLogin)
                {
                    string postLogoutRedirectUri = CreateUri(nameof(ManageLogins));
                    await HttpContext.SignOutAsync(FranceConnectConfiguration.ProviderScheme, new AuthenticationProperties { RedirectUri = postLogoutRedirectUri });
                }
                else
                {
                    message = ManageMessageId.RemoveLoginSuccess;
                    Response.Redirect(Url.Action(nameof(ManageLogins), new { Message = message }));
                }
            }
        }
    }

    // // GET: /Manage/ChangePassword
    // [HttpGet]
    // public IActionResult ChangePassword()
    // {
    //     return View();
    // }

    // POST: /Manage/ChangePassword
    [HttpPost, Route("[controller]/ChangePassword", Name = "ChangePassword")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        var user = await GetCurrentUserAsync();
        if (user != null)
        {
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                _logger.LogInformation(3, "User changed their password successfully.");
                return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return Ok(model);
            // return View(model);
        }
        return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
    }

    //
    // GET: /Manage/SetPassword
    // [HttpGet]
    // public IActionResult SetPassword()
    // {
    //     return View();
    // }

    //
    // POST: /Manage/SetPassword
    [HttpPost, Route("[controller]/SetPassword", Name = "SetPassword")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
    {
        var user = await GetCurrentUserAsync();
        if (user != null)
        {
            var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), new { Message = ManageMessageId.SetPasswordSuccess });
            }
            AddErrors(result);
            return Ok(model);
        }
        return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
    }

    //GET: /Manage/ManageLogins
    [HttpGet, Route("[controller]/ManageLogins", Name = "ManageLogins")]
    public async Task<IActionResult> ManageLogins(ManageMessageId? message = null)
    {
        ViewData["StatusMessage"] =
            message == ManageMessageId.RemoveLoginSuccess ? "L'authentification externe a été supprimée."
            : message == ManageMessageId.AddLoginSuccess ? "L'authentification externe a été ajoutée."
            : message == ManageMessageId.Error ? "Une erreur est survenue."
            : "";
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            return View("Error");
        }
        var userLogins = await _userManager.GetLoginsAsync(user);
        var schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
        var availableProviders = schemes.Where(auth => userLogins.All(ul => auth.Name != ul.LoginProvider)).ToList();
        return Ok(new ManageLoginsViewModel()
        {
            IsLinkedToFranceConnect = userLogins.Any(auth => auth.LoginProvider == FranceConnectConfiguration.ProviderScheme),
            CanRemoveExternalLogin = user.PasswordHash != null || userLogins.Count > 1,
            FranceConnectUserAccount = userLogins.FirstOrDefault(auth => auth.LoginProvider == FranceConnectConfiguration.ProviderScheme),
            FranceConnectProvider = availableProviders.FirstOrDefault(auth => auth.Name == FranceConnectConfiguration.ProviderScheme)
        });
    }

    //
    // POST: /Manage/LinkLogin
    [HttpPost, Route("[controller]/LinkLogin", Name = "LinkLogin")]
    [ValidateAntiForgeryToken]
    public IActionResult LinkLogin(string provider)
    {
        // Request a redirect to the external login provider to link a login for the current user
        var redirectUrl = Url.Action("LinkLoginCallback", "Manage");
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, _userManager.GetUserId(User));
        return new ChallengeResult(provider, properties);
    }

    //
    // GET: /Manage/LinkLoginCallback
    [HttpGet, Route("[controller]/LinkLoginCallback", Name = "LinkLoginCallback")]
    public async Task<ActionResult> LinkLoginCallback()
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            return View("Error");
        }
        var info = await _signInManager.GetExternalLoginInfoAsync(await _userManager.GetUserIdAsync(user));
        if (info == null)
        {
            return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.Error });
        }
        var result = await _userManager.AddLoginAsync(user, info);
        ManageMessageId message;
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, info.AuthenticationProperties, info.LoginProvider);
            message = ManageMessageId.AddLoginSuccess;
        }
        else
        {
            message = ManageMessageId.Error;
        }
        return RedirectToAction(nameof(ManageLogins), new { Message = message });
    }

    //
    // GET: /Manage/PivotIdentity
    [HttpGet, Route("[controller]/PivotIdentity", Name = "GetPivotIdentity")]
    public async Task<IActionResult> PivotIdentity()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            throw new NotSupportedException("Can not retrieve external claims");
        }
        var claims = info.Principal.Claims;
        var pivotIdentity = new PivotIdentity
        {
            Gender = GetClaimValue(claims, "gender"),
            Birthdate = Convert.ToDateTime(GetClaimValue(claims, "birthdate")),
            Birthcountry = GetClaimValue(claims, "birthcountry"),
            Birthplace = GetClaimValue(claims, "birthplace"),
            GivenName = GetClaimValue(claims, "given_name"),
            FamilyName = GetClaimValue(claims, "family_name"),
            PreferredName = GetClaimValue(claims, "preferred_username"),
            Email = GetClaimValue(claims, "email")
        };
        return Ok(pivotIdentity);
    }


    #region Helpers

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }

    public enum ManageMessageId
    {
        AddLoginSuccess,
        ChangePasswordSuccess,
        SetPasswordSuccess,
        RemoveLoginSuccess,
        Error
    }

    private async Task<Account> GetCurrentUserAsync()
    {
        return await _userManager.GetUserAsync(HttpContext.User);
    }

    private string CreateUri(string action)
    {
        string protocol = Request.IsHttps ? "https" : "http";
        return string.Format("{0}://{1}{2}", protocol, Request.Host, Url.Action(action));
    }

    private static string GetClaimValue(IEnumerable<Claim> claims, string claimType)
    {
        var claim = claims.FirstOrDefault(c => c.Type == claimType);
        if (claim != null)
        {
            return claim.Value;
        }
        else
        {
            return string.Empty;
        }
    }

    #endregion
}

﻿using Artisashop.Models.ViewModel.Accounts;

namespace Artisashop.Controllers;

using Artisashop.Configurations;
using Artisashop.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http;

[ApiController]
[Produces("application/json")]
[Route("api/account/")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly SignInManager<Account> _signInManager;
    private readonly UserManager<Account> _userManager;
    private readonly IConfiguration _configuration;
    private readonly StoreDbContext _db;
    private readonly IUtils _utils;
    private readonly FranceConnectConfiguration _franceConnectConfiguration;
    private readonly ILogger<AccountController> _logger;
    private readonly HttpClient _opencageDataClient = new HttpClient();

    public IMailService MailService { get; }

    public AccountController(
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IConfiguration configuration,
        StoreDbContext db,
        IUtils utils,
        IMailService mailService,
        IOptions<FranceConnectConfiguration> franceConnectConfiguration,
        ILoggerFactory loggerFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _db = db;
        _utils = utils;
        MailService = mailService;
        _franceConnectConfiguration = franceConnectConfiguration.Value;
        _logger = loggerFactory.CreateLogger<AccountController>();

        _opencageDataClient.BaseAddress = new Uri("https://api.opencagedata.com/");
        _opencageDataClient.DefaultRequestHeaders.Accept.Clear();
        _opencageDataClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AccountToken), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.Users.SingleAsync(r => r.UserName == model.Email);
                var roles = await _userManager.GetRolesAsync(user);
                var viewModel = new AccountViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    ProfilePicture = user.ProfilePicture,
                    Roles = roles?.ToList() ?? new List<string>(),
                };
                var token = new AccountToken(viewModel, await GenerateJwtToken(user));
                MailService.SendMail(user.Email, "Connexion", $"Vous vous êtes connecté à Artisashop depuis l'adresse IP {this.HttpContext.Connection.RemoteIpAddress}");
                return Ok(token);
            }

            return BadRequest("Login failed");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AccountToken), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Register([FromBody] Register model)
    {
        try
        {
            var user = await CreateUser(model, new[] { Roles.User });
            await _signInManager.SignInAsync(user, false);
            var roles = await _userManager.GetRolesAsync(user);
            var viewModel = new AccountViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                ProfilePicture = user.ProfilePicture,
                Roles = roles?.ToList() ?? new List<string>(),
            };
            var token = new AccountToken(viewModel, await GenerateJwtToken(user));
            MailService.SendMail(user.Email, "Bienvenue chez Artisashop !", $"Bonjour {user.UserName}, nous vous souhaitons la bienvenue sur Artisashop ! Vous pouvez dès à présent explorer notre site et passer vos commandes. N'hésitez pas à nous contacter si vous avez la moindre question. A bientôt ! L'équipe Artisashop");
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private async Task<Account> CreateUser(Register model, string[]? roles = null)
    {
        roles ??= new string[] { Roles.User };

        var account = new Account(model);

        if (account.Address != null)
            account.AddressGPS = await AddressToGPSCoord(account.Address);


        var result = await _userManager.CreateAsync(account, model.Password);
        // TODO: Create exception types
        if (!result.Succeeded)
            throw new Exception(string.Join("\n", result.Errors.Select(e => $"Error: {e.Code} - {e.Description}")));
        account = await _userManager.Users.SingleAsync(r => r.UserName == model.Email);

        var roleResult = await _userManager.AddToRolesAsync(account, roles);
        if (!roleResult.Succeeded)
            throw new Exception(roleResult.Errors.ToString());
        return account;
    }

    // private async Task SignInAccount(Account account, bool isPersistent = false)
    //     => await _signInManager.SignInAsync(account, isPersistent);

    [HttpGet]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Account), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccount()
    {
        try
        {
            Account account = await _utils.GetFromCookie(Request, _db);

            return Ok(account);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("byEmail/{email}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(GetAccountResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccountFromEmail(string email)
    {
        try
        {
            Account? account = await _db.Users!.SingleOrDefaultAsync(user => user.Email == email);
            if (account == null)
                return NotFound($"User with email {email} not found");
            IList<string>? roles = await _userManager.GetRolesAsync(account);
            if (roles == null)
                return BadRequest($"Impossible to get roles for user {email}");
            return Ok(new GetAccountResult(account, roles));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(GetAccountResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccountId(string id)
    {
        try
        {
            Account? account = await _db.Users!.SingleOrDefaultAsync(user => user.Id == id);
            if (account == null)
                return NotFound($"User with id {id} not found");
            IList<string>? roles = await _userManager.GetRolesAsync(account);
            if (roles == null)
                return BadRequest($"Impossible to get roles for user {id}");
            return Ok(new GetAccountResult(account, roles));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Assigns or removes a role to a user.
    /// Available roles are found in <see cref="Roles"/>
    /// </summary>
    /// <param name="id">Id of the user</param>
    /// <param name="role">Name of the role</param>
    /// <param name="isDeleted">Is the role added or deleted</param>
    /// <returns></returns>
    [HttpPost("{id}/role/{role}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(GetAccountResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateRole(string id, string role, bool isDeleted)
    {
        try
        {
            Account? account = await _db.Users!.SingleOrDefaultAsync(craftsman => craftsman.Id == id);
            if (account == null)
                return NotFound($"Craftsman with id {id} not found");
            IdentityResult identityResult;

            var identityRole = _db.Roles.FirstOrDefault(x => x.NormalizedName == role.ToUpper());
            if (identityRole == null)
            {
                return NotFound($"Role {role} not found");
            }

            if (isDeleted)
            {
                identityResult = await _userManager.RemoveFromRoleAsync(account, role.ToUpper());
            }
            else
            {
                identityResult = await _userManager.AddToRoleAsync(account, role.ToUpper());
            }

            if (!identityResult.Succeeded)
            {
                return BadRequest(
                    $"Impossible to update roles for user {id} : {FormatErrorMessages(identityResult.Errors)}");
            }

            return Ok($"Role {role} {(isDeleted ? "removed" : "added")} to user {id}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Account), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccount model)
    {
        try
        {
            Account account = await _utils.GetFromCookie(Request, _db);

            _utils.UpdateObject(account, model);
            await _userManager!.UpdateAsync(account);
            await _db.SaveChangesAsync();
            return Ok(account);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteAccount()
    {
        try
        {
            Account account = await _utils.GetFromCookie(Request, _db);

            await _userManager.DeleteAsync(account);
            await _db.SaveChangesAsync();
            MailService.SendMail(account.Email, "C'est le coeur brisé que nous nous disons au revoir...", "Votre compte a été supprimé. Nous sommes désolés de vous voir partir.");
            return Ok("User with id " + account.UserName + " successfully deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //
    // POST: /Account/ExternalLogin
    [HttpPost("external-login")]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult ExternalLogin(string provider, string? returnUrl = null)
    {
        // Request a redirect to the external login provider.
        var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }

    //
    // GET: /Account/ExternalLoginCallback
    [HttpGet("external-login-callback")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ExternalLoginConfirmationViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null)
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            return RedirectToAction(nameof(Login));
        }

        // acr_values are mapped to this authnclassreference claim by .NET
        string? acrValues = info.Principal?.FindFirst("http://schemas.microsoft.com/claims/authnclassreference")?.Value;
        if (!Validation.IsEIdasLevelMet(acrValues!, _franceConnectConfiguration.EIdasLevel))
        {
            // TODO: Figure that out
            // await HttpContext.SignOutAsync(FranceConnectConfiguration.ProviderScheme, new AuthenticationProperties { RedirectUri = Url.Action(nameof(Login), null, null, Request.Scheme) });
            throw new UnauthorizedAccessException("Requested EIdas level not met");
        }

        // Sign in the user with this external login provider if the user already has a login.
        var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
        if (user != null)
        {
            if (await _userManager.IsLockedOutAsync(user))
            {
                // TODO: replace
                // return View("Lockout");
                return Ok();
            }

            await _signInManager.SignInAsync(user, info.AuthenticationProperties, info.LoginProvider);
            _logger.LogInformation(5, "User logged in with {Name} provider.", info.LoginProvider);
            // TODO: replace
            // return RedirectToLocal(returnUrl ?? Url.Action(nameof(ManageController.PivotIdentity), "Manage"));
            return Ok(returnUrl ?? Url.Action(nameof(ManageController.PivotIdentity), "Manage"));
        }
        else
        {
            // TODO: replace
            // If the user does not have an account, then ask the user to create an account.
            // ViewData["ReturnUrl"] = returnUrl;
            // ViewData["LoginProvider"] = info.ProviderDisplayName;

            DateTime.TryParseExact(info.Principal.FindFirstValue("birthdate"), "yyyy-MM-dd", new CultureInfo("fr-FR"),
                DateTimeStyles.AssumeUniversal, out DateTime parsedBirthDate);
            ExternalLoginConfirmationViewModel model = new()
            {
                Email = info.Principal.FindFirstValue("email"),
                Gender = info.Principal.FindFirstValue("gender"),
                Birthdate = parsedBirthDate,
                PreferredName = info.Principal.FindFirstValue("preferred_username"),
                GivenName = info.Principal.FindFirstValue("given_name"),
                FamilyName = info.Principal.FindFirstValue("family_name")
            };
            // return View("ExternalLoginConfirmation", model);
            return Ok(model);
        }
    }

    private Task<string> GenerateJwtToken(Account user)
    {
        var roles = _userManager.GetRolesAsync(user).Result;

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var jwtConfiguration = _configuration.GetSection("Jwt").Get<JwtConfiguration>();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtConfiguration.ExpireDays)).AddHours(2).AddMinutes(30);

        var token = new JwtSecurityToken(
            jwtConfiguration.Issuer,
            jwtConfiguration.Audience,
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    /*[HttpGet("GetTestAddressToGPSCoord")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GPSCoord), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTestAddressToGPSCoord([FromQuery] string address)
    {
        try {
            return Ok(await AddressToGPSCoord(address));
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }*/

    [HttpGet("nbOfResultByAddress")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<int> NbOfResultByAddress(string address)
    {
        string GoogleKey = "acdfe36c88484444850da3d8adb97890";
        int ret = 0;
        HttpResponseMessage response =
            await _opencageDataClient.GetAsync("geocode/v1/json?key=" + GoogleKey + "&q=" + address);
        if (response.IsSuccessStatusCode)
        {
            OpencageDataGeocode ODG = (await response.Content.ReadFromJsonAsync<OpencageDataGeocode>())!;
            if (ODG.Results != null)
                ret = ODG.Results.Count();
        }

        return ret;
    }

    [HttpGet("opencageDataGeocodeByAddress")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(OpencageDataGeocode), (int)HttpStatusCode.OK)]
    public async Task<OpencageDataGeocode> OpencageDataGeocodeByAddress(string address)
    {
        string GoogleKey = "acdfe36c88484444850da3d8adb97890";
        OpencageDataGeocode? ret = null;
        HttpResponseMessage response =
            await _opencageDataClient.GetAsync("geocode/v1/json?key=" + GoogleKey + "&q=" + address);
        if (response.IsSuccessStatusCode)
        {
            ret = (await response.Content.ReadFromJsonAsync<OpencageDataGeocode>())!;
        }

        return (ret != null) ? ret : new OpencageDataGeocode();
    }

    private async Task<GPSCoord> AddressToGPSCoord(string address)
    {
        string GoogleKey = "acdfe36c88484444850da3d8adb97890";
        GPSCoord? ret = null;
        OpencageDataGeocode tmp;
        HttpResponseMessage response =
            await _opencageDataClient.GetAsync("geocode/v1/json?key=" + GoogleKey + "&q=" + address);
        if (response.IsSuccessStatusCode)
        {
            tmp = (await response.Content.ReadFromJsonAsync<OpencageDataGeocode>())!;
            if (tmp.Results != null)
                ret = tmp.Results[0].Geometry;
        }

        return (ret != null) ? ret : new GPSCoord();
    }

    private string FormatErrorMessages(IEnumerable<IdentityError> errors)
        => ConcatErrorMessages(errors.Select(x => $"{x.Code} - {x.Description}"));

    private string ConcatErrorMessages(IEnumerable<string> messages)
        => string.Join(", ", messages);
}

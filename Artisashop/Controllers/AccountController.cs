namespace Artisashop.Controllers;

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
using Artisashop.Validation;
using System.Globalization;
using Artisashop.Models.ViewModel.Account;

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

    public AccountController(
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IConfiguration configuration,
        StoreDbContext db,
        IUtils utils,
        IOptions<FranceConnectConfiguration> franceConnectConfiguration,
        ILoggerFactory loggerFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _db = db;
        _utils = utils;
        _franceConnectConfiguration = franceConnectConfiguration.Value;
        _logger = loggerFactory.CreateLogger<AccountController>();
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
                var appUser = await _userManager.Users.SingleAsync(r => r.UserName == model.Email);
                var userToken = new AccountToken(new AccountViewModel(appUser), await GenerateJwtToken(appUser));
                return Ok(userToken);
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
            Account account = new(model)
            {
                Id = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(account, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            IdentityResult identityResult = await _userManager.AddToRoleAsync(account, Account.UserType.CONSUMER.ToString());
            if (!identityResult.Succeeded)
                return BadRequest(identityResult.Errors);
            identityResult = await _userManager.AddToRoleAsync(account, model.Role.ToString());
            if (identityResult.Succeeded)
            {
                var appUser = await _userManager.Users.SingleAsync(r => r.UserName == model.Email);
                await _signInManager.SignInAsync(appUser, false);
                var userToken = new AccountToken(new AccountViewModel(appUser), await GenerateJwtToken(appUser));
                return Ok(userToken);
            }

            return BadRequest(result.ToString());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

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

    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Account), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAccountId(string id)
    {
        try
        {
            Account? account = await _db.Users!.SingleOrDefaultAsync(craftsman => craftsman.Id == id);
            if (account == null)
                return NotFound("Craftsman with id " + id + " not found");
            return Ok(account);
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

            DateTime.TryParseExact(info.Principal.FindFirstValue("birthdate"), "yyyy-MM-dd", new CultureInfo("fr-FR"), DateTimeStyles.AssumeUniversal, out DateTime parsedBirthDate);
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
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, user.Role.ToString() ?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}

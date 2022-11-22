namespace Artisashop.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Net.Http;
using Artisashop.Models.ViewModel.Accounts;
using Artisashop.Configurations;
using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Services;

[ApiController]
[Produces("application/json")]
[Route("api/account/")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly SignInManager<Account> _signInManager;
    private readonly IAccountService<Account> _accountService;
    private readonly UserManager<Account> _userManager;
    private readonly IConfiguration _configuration;
    private readonly StoreDbContext _db;
    private readonly FranceConnectConfiguration _franceConnectConfiguration;
    private readonly ILogger<AccountController> _logger;
    private readonly HttpClient _opencageDataClient = new HttpClient();

    public AccountController(
        IAccountService<Account> accountService,
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IConfiguration configuration,
        StoreDbContext db,
        IOptions<FranceConnectConfiguration> franceConnectConfiguration,
        ILoggerFactory loggerFactory)
    {
        _accountService = accountService;

        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _db = db;
        _franceConnectConfiguration = franceConnectConfiguration.Value;
        _logger = loggerFactory.CreateLogger<AccountController>();

        _opencageDataClient.BaseAddress = new Uri("https://api.opencagedata.com/");
        _opencageDataClient.DefaultRequestHeaders.Accept.Clear();
        _opencageDataClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<Results<BadRequest<string>, Ok<AccountToken>>> Login([FromBody] Login model)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                throw new ArtisashopException("Invalid login attempt.");
            }
            
            var roles = await _userManager.GetRolesAsync(user);
            
            

            
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                // var user = await _userManager.Users.SingleAsync(r => r.UserName == model.Email);
                // var roles = await _userManager.GetRolesAsync(user);
                var viewModel = new AccountViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    Roles = roles?.ToList() ?? new List<string>(),
                };
                var token = new AccountToken(viewModel, await GenerateJwtToken(user));
                return TypedResults.Ok(token);
            }

            return TypedResults.BadRequest("Login failed");
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<Results<Ok<AccountToken>, BadRequest<string>>> Register([FromBody] Register model)
    {
        try
        {
            var account = new Account
            {
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
            };
            await _accountService.RegisterAsync(account, model.Password!);
            var user = await _accountService.GetFromEmailAsync(model.Email!);
            await _accountService.AddToRoleAsync(user!, Roles.User);
            await _signInManager.SignInAsync(user!, false);
            
            var roles = await _userManager.GetRolesAsync(user!);
            var viewModel = new AccountViewModel
            {
                Id = user!.Id,
                Username = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                Roles = roles?.ToList() ?? new List<string>(),
            };
            var token = new AccountToken(viewModel, await GenerateJwtToken(user));
            return TypedResults.Ok(token);
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
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
            // TODO: FIX
            // Account account = await RandomUtils.GetFromCookie(Request, _db);

            // return Ok(account);
            throw new NotImplementedException();
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
            Account? account = await _db.Users!.SingleOrDefaultAsync(craftsman => craftsman.Id == id);
            if (account == null)
                return NotFound($"Craftsman with id {id} not found");
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
            // Account account = await Utils.GetFromCookie(Request, _db);

            // _utils.UpdateObject(account, model);
            // await _userManager!.UpdateAsync(account);
            // await _db.SaveChangesAsync();
            // return Ok(account);
            // TODO: FIX
            throw new NotImplementedException();
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
            // Account account = await _utils.GetFromCookie(Request, _db);

            // await _userManager.DeleteAsync(account);
            // await _db.SaveChangesAsync();
            // return Ok("User with id " + account.UserName + " successfully deleted");

            // TODO: FIX
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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
        var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtConfiguration.Expiration));

        var token = new JwtSecurityToken(
            jwtConfiguration.Issuer,
            jwtConfiguration.Audience,
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
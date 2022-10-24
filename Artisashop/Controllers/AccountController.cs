using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Artisashop.Models.ViewModel;

namespace Artisashop.Controllers
{
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

        public AccountController(
            UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            IConfiguration configuration,
            StoreDbContext db,
            IUtils utils)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _db = db;
            _utils = utils;
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

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(account, false);
                    var userToken = new AccountToken(new AccountViewModel(account), await GenerateJwtToken(account));
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
        public async Task<IActionResult> GetAccountId([FromQuery] string id)
        {
            try
            {
                Account? account = await _db.Accounts!.SingleOrDefaultAsync(craftsman => craftsman.Id == id);
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
}

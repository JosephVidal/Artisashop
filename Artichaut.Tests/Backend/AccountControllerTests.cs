using Artichaut.Models;
using Artichaut.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Artichaut.Tests.Backend
{
    [Order(1)]
    [TestFixture]
    public static class AccountControllerTest
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        public static string? token;

        [Order(1)]
        [TestCase("jean.epp@epitech.eu", "Jean", "Epp", "Password_1234", Account.UserType.ADMIN, null)]
        [TestCase("john.artisan@epitech.eu", "Jean", "Epp", "Password_1234", Account.UserType.CRAFTSMAN, null)]
        [TestCase("baby.partner@epitech.eu", "Jean", "Epp", "Password_1234", Account.UserType.PARTNER, null)]
        [TestCase("jane.consumer@epitech.eu", "Jean", "Epp", "Password_1234", Account.UserType.CONSUMER, null)]
        [TestCase("delete.user@epitech.eu", "Delete", "User", "Password_1234", Account.UserType.CONSUMER, null)]
        public static async Task Register(string email, string firstname, string lastname, string password, Account.UserType role, string job)
        {
            Register model = new()
            {
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                Password = password,
                Role = role,
                Job = job
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/account/register");
            postRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            AccountToken? result = await response.Content.ReadFromJsonAsync<AccountToken>();

            Assert.NotNull(result);
            Assert.NotNull(result!.User);
            Assert.NotNull(result.Token);
            Assert.AreEqual(email, result.User!.Username);
            token = result.Token;
        }

        [Order(2)]
        [TestCase("delete.user@epitech.eu", "Password_1234")]
        public static async Task Login(string mail, string password)
        {
            Login model = new()
            {
                Email = mail,
                Password = password
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/account/login");
            postRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            AccountToken? result = await response.Content.ReadFromJsonAsync<AccountToken>();

            Assert.NotNull(result);
            Assert.NotNull(result!.User);
            Assert.NotNull(result.Token);
            Assert.AreEqual(mail, result.User!.Username);
            token = result.Token;
        }

        [Test]
        [Order(3)]
        public static async Task GetUser()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/account/info");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Account? result = await response.Content.ReadFromJsonAsync<Account>();
            Assert.NotNull(result);
            Assert.AreEqual("delete.user@epitech.eu", result!.Email);
        }

        [Test]
        [Order(4)]
        public static async Task UpdateUser()
        {
            UpdateAccount model = new()
            {
                Email = "delete.user@epitech.eu",
                Firstname = "Charles",
                Lastname = "Choco",
                PhoneNumber = "+33123456789",
                Job = "Brouteur"
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/account/update");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Account? result = await response.Content.ReadFromJsonAsync<Account>();
            Assert.NotNull(result);
            Assert.AreEqual("delete.user@epitech.eu", result!.Email);
            Assert.AreEqual("Charles", result!.Firstname);
            Assert.AreEqual("Choco", result!.Lastname);
        }

        [Test]
        [Order(4)]
        public static async Task DeleteUser()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/account/delete");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            string? result = await response.Content.ReadFromJsonAsync<string>();

            Assert.AreEqual("User with id delete.user@epitech.eu successfully deleted", result);
        }
    }
}
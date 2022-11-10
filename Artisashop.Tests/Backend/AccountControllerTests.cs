using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using System.Net;
using NUnit.Framework;
using Artisashop.Models;
using Artisashop.Models.ViewModel;

namespace Artisashop.Tests.Backend
{
    public enum TestReturn
    {
        OK,
        BADREQUEST
    }

    [Order(1)]
    [TestFixture]
    public static class AccountControllerTest
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        public static string? token;
        public static List<string> ids = new List<string>();

        [Order(1)]
        [TestCase("jean.epp@epitech.eu", "Jean", "Epp", "Password_1234", Account.UserType.ADMIN, null, "", TestName = "Add Jean Epp", Category = "Register Success")]
        [TestCase("john.artisan@epitech.eu", "John", "Artisan", "Password_1234", Account.UserType.CRAFTSMAN, null, "", TestName = "Add John Artisan", Category = "Register Success")]
        [TestCase("baby.partner@epitech.eu", "Baby", "Partner", "Password_1234", Account.UserType.PARTNER, null, "", TestName = "Add Baby Partner", Category = "Register Success")]
        [TestCase("jane.consumer@epitech.eu", "Jane", "Consumer", "Password_1234", Account.UserType.CONSUMER, null, "", TestName = "Add Jane Consumer", Category = "Register Success")]
        [TestCase("delete.user@epitech.eu", "Delete", "User", "Password_1234", Account.UserType.CONSUMER, null, "", TestName = "Add Delete User", Category = "Register Success")]
        [TestCase("delete.user@epitech.eu", "Delete", "User", "Password_1234", Account.UserType.CONSUMER, null, "Error", TestName = "Account already exist", Category = "Register Fail")]
        public static async Task Register(string email, string firstname, string lastname, string password, Account.UserType role, string job, string responseType)
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

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/account");
            postRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                AccountToken? result = await response.Content.ReadFromJsonAsync<AccountToken>();

                Assert.NotNull(result);
                Assert.NotNull(result!.User);
                Assert.NotNull(result.Token);
                Assert.AreEqual(email, result.User!.Username);
                token = result.Token;
                ids.Add(result.User.Id!);
            }
            catch (Exception)
            {
                if (responseType == "Error")
                {
                    Assert.AreEqual("Failed : DuplicateUserName", await response.Content.ReadFromJsonAsync<string>());
                }
            }
        }

        [Order(2)]
        [TestCase("delete.user@epitech.eu", "Password_1234", TestName = "Login Delete User", Category = "Login Success")]
        [TestCase("delete.user@epitech.eu", "", "Error", TestName = "Login Fail", Category = "Login Fail")]
        public static async Task Login(string mail, string password, string? responseType = null)
        {
            Login model = new()
            {
                Email = mail,
                Password = password
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/account/login");
            postRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                AccountToken? result = await response.Content.ReadFromJsonAsync<AccountToken>();

                Assert.NotNull(result);
                Assert.NotNull(result!.User);
                Assert.NotNull(result.Token);
                Assert.AreEqual(mail, result.User!.Username);
                token = result.Token;
            }
            catch (Exception)
            {
                if (responseType == "Error")
                {
                    Assert.AreEqual("Failed", (await response.Content.ReadFromJsonAsync<SignInResult>())!.ToString());
                }
            }
        }

        [Order(3)]
        [TestCase(TestName = "Get Delete User", Category = "GetUser Success")]
        public static async Task GetUser()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/account");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            Account? result = await response.Content.ReadFromJsonAsync<Account>();
            Assert.NotNull(result);
            Assert.AreEqual("delete.user@epitech.eu", result!.Email);
        }

        [Order(3)]
        [TestCase("0", TestName = "Get Delete User by id", Category = "GetAccountId Success")]
        [TestCase("rugfqoelhfpfdbqoezgf", "NotFound", TestName = "GetAccountId Fail", Category = "GetAccountId Fail")]
        public static async Task GetAccountId(string id = "", string responseType = "")
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/account/" + (int.TryParse(id, out int idt) == true ? ids[idt] : id));
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Account? result = await response.Content.ReadFromJsonAsync<Account>();
                Assert.NotNull(result);
                Assert.AreEqual("jean.epp@epitech.eu", result!.Email);
            } catch (Exception)
            {
                if (responseType == "NotFound")
                {
                    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
                }
            }
        }

        [Order(4)]
        [TestCase(TestName = "Update Delete User", Category = "UpdateUser Success")]
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

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/account");
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

        [Order(4)]
        [TestCase(TestName = "Delete Delete User", Category = "DeleteUser Success")]
        public static async Task DeleteUser()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/account");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            string? result = await response.Content.ReadFromJsonAsync<string>();

            Assert.AreEqual("User with id delete.user@epitech.eu successfully deleted", result);
        }
    }
}
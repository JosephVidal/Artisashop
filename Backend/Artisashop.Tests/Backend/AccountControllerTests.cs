using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Artisashop.Models.ViewModel;
using Artisashop.Models;
using Artisashop.Models.ViewModel.Accounts;

namespace Artisashop.Tests.Backend
{
    public enum TestReturn
    {
        OK,
        BADREQUEST
    }

    [TestFixture]
    public static class AccountControllerTest
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        public static string? token;
        public static List<string> ids = new List<string>();

        [Order(1)]
        [TestCase("jean.epp@epitech.eu", "Jean", "Epp", "Password_1234", Roles.Admin, null, TestName = "Add Jean Epp", Category = "Register Success")]
        [TestCase("john.artisan@epitech.eu", "John", "Artisan", "Password_1234", Roles.Seller, "Ebeniste", TestName = "Add John Artisan", Category = "Register Success")]
        [TestCase("baby.partner@epitech.eu", "Baby", "Partner", "Password_1234", Roles.Partner, null, TestName = "Add Baby Partner", Category = "Register Success")]
        [TestCase("jane.consumer@epitech.eu", "Jane", "Consumer", "Password_1234", Roles.User, null, TestName = "Add Jane Consumer", Category = "Register Success")]
        [TestCase("delete.user@epitech.eu", "Delete", "Account", "Password_1234", Roles.User, null, TestName = "Add Delete Account", Category = "Register Success")]
        [TestCase("delete.user@epitech.eu", "Delete", "Account", "Password_1234", Roles.User, null, "Error: DuplicateUserName - Username 'delete.user@epitech.eu' is already taken.", TestName = "Account already exist", Category = "Register Fail")]
        public static async Task Register(string email, string firstname, string lastname, string password, string role, string job, string expt = null)
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
                Common.Control(expt, response!);
            }
        }

        [Order(2)]
        [TestCase("delete.user@epitech.eu", "Password_1234", TestName = "Login Delete Account", Category = "Login Success")]
        [TestCase("delete.user@epitech.eu", "", "Failed", typeof(SignInResult), TestName = "Login Fail", Category = "Login Fail")]
        public static async Task Login(string mail, string password, string? expt = null, Type? responseType = null)
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
                Common.Control(expt!, response, responseType);
            }
        }

        [Order(3)]
        [TestCase(TestName = "Get Delete Account", Category = "GetUser Success")]
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
        [TestCase("0", "jean.epp@epitech.eu", TestName = "Get Delete Account by id", Category = "GetAccountId Success")]
        [TestCase("rugfqoelhfpfdbqoezgf", "Craftsman with id rugfqoelhfpfdbqoezgf not found", TestName = "GetAccountId Fail", Category = "GetAccountId Fail")]
        public static async Task GetAccountId(string id, string expt)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/account/" + (int.TryParse(id, out int idt) == true ? ids[idt] : id));
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                GetAccountResult? result = await response.Content.ReadFromJsonAsync<GetAccountResult>();
                Assert.NotNull(result);
                Assert.AreEqual(expt, result!.Account.Email);
            } catch (Exception)
            {
                Common.Control(expt, response);
            }
        }

        [Order(4)]
        [TestCase(TestName = "Update Delete Account", Category = "UpdateUser Success")]
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
        [TestCase(TestName = "Delete Delete Account", Category = "DeleteUser Success")]
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
using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Artisashop.Models.ViewModel;
using Artisashop.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace Artisashop.Tests.Backend
{
    [TestFixture]
    public class BackofficeControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jean.epp@epitech.eu", "Password_1234");
            _token = AccountControllerTest.token;
        }

        [Test]
        public async Task Index()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/backoffice");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Account>? result = await response.Content.ReadFromJsonAsync<List<Account>>();
            Assert.NotNull(result);
        }

        [Test]
        public async Task Stats()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/backoffice/stats");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Home? result = await response.Content.ReadFromJsonAsync<Home>();
            Assert.NotNull(result);
            Assert.AreEqual(2, result!.ProductNumber);
            Assert.AreEqual(1, result!.CraftsmanNumber);
            Assert.AreEqual(2, result!.Inscrit);
        }

        [TestCase("john.artisan@epitech.eu", true)]
        public async Task ChangeCraftsmanValidationStatus(string username, bool validationStatus)
        {
            Dictionary<string, string> data = new()
            {
                { "username", username },
                { "validationStatus", validationStatus.ToString() }
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/backoffice/changeValidationStatus");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            string? result = await response.Content.ReadFromJsonAsync<string>();
            Assert.NotNull(result);
            Assert.AreEqual("Validation status for " + username + " : " + !validationStatus, result);
        }
    }
}
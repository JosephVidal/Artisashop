using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System;
using Artisashop.Models;
using Artisashop.Models.ViewModel;

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
            await AccountControllerTest.Login("jean@artisashop.fr", "Artisashop@2022");
            _token = AccountControllerTest.token;
        }

        [TestCase(TestName = "Craftsman dashboard", Category = "Index Success")]
        public async Task Index()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/backoffice");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Account>? result = await response.Content.ReadFromJsonAsync<List<Account>>();
            Assert.NotNull(result);
        }

        [TestCase(TestName = "Stats", Category = "Stats Success")]
        public async Task Stats()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/backoffice/stats");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Home? result = await response.Content.ReadFromJsonAsync<Home>();
            Assert.NotNull(result);
            Assert.AreEqual(27, result!.ProductNumber);
            Assert.AreEqual(10, result!.CraftsmanNumber);
            Assert.AreEqual(100, result!.Inscrit);
        }
    }
}
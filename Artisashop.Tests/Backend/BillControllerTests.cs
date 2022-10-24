using Backend.Models;
using Backend.Models.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Artisashop.Tests.Backend
{
    public class BillControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jane.consumer@epitech.eu", "Password_1234");
            _token = AccountControllerTest.token;
        }

        [Order(1)]
        [Test]
        public async Task BasketToPaypalBill()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/bill");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            PaypalBill? result = await response.Content.ReadFromJsonAsync<PaypalBill>();
            Assert.NotNull(result);
        }

        [Order(2)]
        [Test]
        public async Task BasketSold()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/bill");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Bill>? result = await response.Content.ReadFromJsonAsync<List<Bill>>();
            Assert.NotNull(result);
        }
    }
}

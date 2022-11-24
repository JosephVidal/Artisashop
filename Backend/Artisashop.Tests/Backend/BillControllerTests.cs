using Artisashop.Models;
using Artisashop.Models.ViewModel;
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
            await AccountControllerTest.Login("jane.consumer@artisashop.fr", "Artisashop@2022");
            _token = AccountControllerTest.token;
        }

        [Order(1)]
        [TestCase(TestName = "Show final bill", Category = "BasketToPaypalBill Success")]
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
        [TestCase(TestName = "Paying success", Category = "Basket Success")]
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

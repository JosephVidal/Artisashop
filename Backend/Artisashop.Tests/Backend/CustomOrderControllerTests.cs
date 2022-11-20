using Artisashop.Models;
using Artisashop.Models.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Artisashop.Models.Basket;

namespace Artisashop.Tests.Backend
{
    [TestFixture]
    public class CustomOrderControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _tokenConsumer;
        private string? _tokenCraftsman;
        private List<string> _ids = new List<string>();

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jane.consumer@epitech.eu", "Password_1234");
            _tokenConsumer = AccountControllerTest.token;
            await AccountControllerTest.Login("john.artisan@epitech.eu", "Password_1234");
            _tokenCraftsman = AccountControllerTest.token;
            _ids = AccountControllerTest.ids;
        }

        [Test]
        public async Task OrderList()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/custom-order/list");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenCraftsman);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Basket>? result = await response.Content.ReadFromJsonAsync<List<Basket>>();
            Assert.NotNull(result);
            Assert.AreNotEqual(0, result!.Count);
        }

        [Test]
        public async Task GetCreate()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/custom-order/" + _ids![1]);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Account? result = await response.Content.ReadFromJsonAsync<Account>();
            Assert.NotNull(result);
        }

        [TestCase("Ma Table", "Ma très jolie table", 3)]
        public async Task Create(string name, string desc, int quantity)
        {
            CreateCustomOrder order = new(_ids[1], name, desc, quantity);

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/custom-order");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(result);
        }

        [TestCase(3)]
        public async Task GetUpdate(int basketId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/custom-order/update/" + basketId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(result);
        }

        [TestCase(1, DeliveryOption.TAKEOUT, "Ma Chaise", "Ma tres jolie chaise", 29.99, "[]", "[]")]
        public async Task Update(int quantity, DeliveryOption deliveryOpt, string name, string description, decimal price, string images, string styles)
        {
            UpdateCustomOrder basket = new()
            {
                Id = 3,
                Quantity = quantity,
                DeliveryOpt = deliveryOpt,
                Name = name,
                Price = price,
                Description = description
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/custom-order");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(basket), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(result);
        }

        [TestCase(3, DeliveryOption.DELIVERY)]
        public async Task UpdateStatus(int basketId, DeliveryOption deliveryOpt)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/custom-order/" + basketId + "/changeStatus");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(deliveryOpt), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            DeliveryOption? result = await response.Content.ReadFromJsonAsync<DeliveryOption>();
            Assert.NotNull(result);
        }
    }
}

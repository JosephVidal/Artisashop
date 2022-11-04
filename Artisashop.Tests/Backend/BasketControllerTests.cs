using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Backend.Models;
using static Backend.Models.Basket;
using Backend.Models.ViewModel;

namespace Artisashop.Tests.Backend
{
    [TestFixture]
    public class BasketControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jane.consumer@epitech.eu", "Password_1234");
            _token = AccountControllerTest.token;
        }

        [Order(2)]
        [Test]
        public async Task Index()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/basket");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Basket>? result = await response.Content.ReadFromJsonAsync<List<Basket>>();
            Assert.NotNull(result);
            Assert.AreNotEqual(0, result!.Count);
        }

        [Order(1)]
        [TestCase(1, 3)]
        [TestCase(3, 6)]
        public async Task Add(int productID, int quantityModifier)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/basket?productID=" + productID + "&quantityModifier=" + quantityModifier);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(result);
        }

        [Order(3)]
        [TestCase(1, 2, DeliveryOption.DELIVERY, State.ONGOING)]
        public async Task Update(int id, int quantity, DeliveryOption deliveryOpt, State currentState)
        {
            UpdateBasket basket = new()
            {
                Id = id,
                Quantity = quantity,
                DeliveryOpt = deliveryOpt,
                CurrentState = currentState
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/basket");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(basket), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(result);
        }

        [Order(4)]
        [TestCase(1)]
        public async Task Delete(int basketId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/basket/" + basketId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            string? result = await response.Content.ReadFromJsonAsync<string>();
            Assert.NotNull(result);
            Assert.AreEqual("Basket item with id " + basketId + " not found", result);
        }

        [Order(5)]
        [TestCase("4 rue de l'arc-en-ciel")]
        public async Task Payement(string address)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/basket/pay");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(address), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Dictionary<string, object>? result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            Assert.NotNull(result);
        }
    }
}
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Artisashop.Models;
using static Artisashop.Models.Basket;
using Artisashop.Models.ViewModel;
using System;

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
            await AccountControllerTest.Login("jane.consumer@artisashop.fr", "Artisashop@2022");
            _token = AccountControllerTest.token;
        }

        [Order(2)]
        [TestCase(TestName = "Index Success", Category = "Index Success")]
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
        [TestCase(1, 3, TestName = "Add Product with id 1", Category = "Add Success")]
        [TestCase(3, 6, TestName = "Add Product with id 3", Category = "Add Success")]
        [TestCase(7, 8, "Product with id 7 not found", TestName = "Not found", Category = "Add Fail")]
        public async Task Add(int productID, int quantityModifier, string? expt = "")
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/basket?productID=" + productID + "&quantityModifier=" + quantityModifier);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
                Assert.NotNull(result);
            } catch (HttpRequestException)
            {
                Common.Control(expt!, response);
            }
        }

        [Order(3)]
        [TestCase(1, 2, DeliveryOption.DELIVERY, State.ONGOING, TestName = "Update Product with id 1", Category = "Update Success")]
        [TestCase(5, 2, DeliveryOption.DELIVERY, State.ONGOING, "Basket with id 5 not found", TestName = "Basket item not found", Category = "Update Fail")]
        public async Task Update(int id, int quantity, DeliveryOption deliveryOpt, State currentState, string? expt = "")
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

            try
            {
                response.EnsureSuccessStatusCode();

                Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
                Assert.NotNull(result);
            } catch (HttpRequestException)
            {
                Common.Control(expt!, response);
            }
        }

        [Order(4)]
        [TestCase(1, TestName = "Delete item with id 1", Category = "Delete Success")]
        [TestCase(6, "Basket item with id 6 not found", TestName = "Basket item 6 not found", Category = "Delete Fail")]
        public async Task Delete(int basketId, string? expt = "")
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/basket/" + basketId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            try
            {
                response.EnsureSuccessStatusCode();

                string? result = await response.Content.ReadFromJsonAsync<string>();
                Assert.NotNull(result);
                Assert.AreEqual("Basket item with id " + basketId + " not found", result);
            } catch (HttpRequestException)
            {
                Common.Control(expt!, response);
            }
        }

        [Order(5)]
        [TestCase("4 rue de l'arc-en-ciel", TestName = "Payment success", Category = "Payment Success")]
        [TestCase("", "Adresse Invalide",  TestName = "Wrong address", Category = "Payment Fail")]
        public async Task Payement(string address, string? expt = "")
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/basket/pay");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(address), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            try
            {
                response.EnsureSuccessStatusCode();

                Dictionary<string, object>? result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                Assert.NotNull(result);
            } catch (HttpRequestException)
            {
                Common.Control(expt!, response);
            }
        }
    }
}
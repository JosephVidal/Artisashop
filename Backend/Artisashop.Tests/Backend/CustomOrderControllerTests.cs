using Artisashop.Models;
using Artisashop.Models.ViewModel;
using NUnit.Framework;
using System;
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

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jane.consumer@artisashop.fr", "Artisashop@2022");
            _tokenConsumer = AccountControllerTest.token;
            await AccountControllerTest.Login("john.artisan@artisashop.fr", "Artisashop@2022");
            _tokenCraftsman = AccountControllerTest.token;
        }

        [TestCase(TestName = "List of orders", Category = "OrderList Success")]
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

        [TestCase("1", TestName = "Get creation formular", Category = "GetCreate Success")]
        [TestCase("ofozyefozyfeo", "Account with id ofozyefozyfeo not found", TestName = "Account not found", Category = "GetCreate Fail")]
        public async Task GetCreate(string id, string? expt = null)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/custom-order/" + id);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);

            var response = await _client.SendAsync(postRequest);
            try
            {
                response.EnsureSuccessStatusCode();

                Account? result = await response.Content.ReadFromJsonAsync<Account>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }

        [TestCase("1", "Ma Table", "Ma très jolie table", 3, TestName = "Create custom order", Category = "Create Success")]
        [TestCase("ziehfpizfehaufg", "Ma Table", "Ma très jolie table", 3, "Craftsman with id ziehfpizfehaufg not found", TestName = "Craftsman not found", Category = "Create Fail")]
        public async Task Create(string id, string name, string desc, int quantity, string? expt = null)
        {
            CreateCustomOrder order = new(id, name, desc, quantity);

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/custom-order");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control("Craftsman with id " + order.CraftsmanId + " not found", response);
            }
        }

        [TestCase(1, TestName = "Get update formular", Category = "GetUpdate Success")]
        [TestCase(3, "Basket item with id 3 not found", TestName = "Basket item 3 not found", Category = "GetUpdate Fail")]
        public async Task GetUpdate(int basketId, string? expt = null)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/custom-order/update/" + basketId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }

        [TestCase(3, DeliveryOption.TAKEOUT, "Ma Chaise", "Ma tres jolie chaise", 29.99, "[]", "[]", TestName = "Update ", Category = "Update Success")]
        [TestCase(5, DeliveryOption.TAKEOUT, "Ma Chaise", "Ma tres jolie chaise", 29.99, "[]", "[]", "Basket with id 5 not found", TestName = "Basket item 5 not found", Category = "Update Fail")]
        public async Task Update(int quantity, DeliveryOption deliveryOpt, string name, string description, double price, string images, string styles, string? expt = null)
        {
            UpdateCustomOrder basket = new()
            {
                Id = 1,
                Quantity = quantity,
                DeliveryOpt = deliveryOpt,
                Name = name,
                Price = decimal.Parse(price.ToString()),
                Description = description
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/custom-order");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(basket), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Basket? result = await response.Content.ReadFromJsonAsync<Basket>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }

        [TestCase(1, State.DELIVERY, TestName = "Update status success", Category = "UpdateStatus Success")]
        [TestCase(6, State.DELIVERY, "Basket with id 6 not found", TestName = "Basket item 6 not found", Category = "UpdateStatus Fail")]
        public async Task UpdateStatus(int basketId, State state, string? expt = null)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/custom-order/" + basketId + "/changeStatus");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenConsumer);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(state), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                State? result = await response.Content.ReadFromJsonAsync<State>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }
    }
}
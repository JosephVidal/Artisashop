using Artisashop.Models;
using Artisashop.Models.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Artisashop.Tests.Backend
{
    [Order(2)]
    [TestFixture]
    public class ProductControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("john.artisan@epitech.eu", "Password_1234");
            _token = AccountControllerTest.token;
        }

        [Order(2)]
        [Test]
        public async Task List()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/product/list");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Product>? result = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.NotNull(result);
        }

        [Order(2)]
        [TestCase(1)]
        public async Task Info(int info)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/product/info/" + info);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Product? result = await response.Content.ReadFromJsonAsync<Product>();
            Assert.NotNull(result);
        }

        [Order(1)]
        [TestCase("Table", "Jolie table", 39.99, 3, "[\"image1\",\"image2\"]", "[\"style1\",\"style2\"]")]
        [TestCase("Chaise", "Jolie chaise", 19.99, 3, "[\"image1\",\"image2\"]", "[\"style1\",\"style2\"]")]
        [TestCase("Lampe", "Jolie lampe", 19.99, 3, "[\"image1\",\"image2\"]", "[\"style1\",\"style2\"]")]
        public async Task Create(string name, string description, decimal price, int quantity, string images, string styles)
        {
            CreateProduct newProduct = new()
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                Images = JsonSerializer.Deserialize<List<string>>(images)!,
                Styles = styles.Select(x => new Style() { Name = x.ToString() }).ToList(),
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/product/create");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(newProduct), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Product? result = await response.Content.ReadFromJsonAsync<Product>();
            Assert.NotNull(result);
            Assert.AreEqual(name, result!.Name);
            Assert.AreEqual(description, result!.Description);
            Assert.AreEqual(price, result!.Price);
            Assert.AreEqual(quantity, result!.Quantity);
            Assert.AreEqual(images, result!.Images!.Select(x => x.Content).ToList());
            Assert.AreEqual(styles, result!.Styles.Select(x => x.Style.Name).ToList());
        }

        [Order(3)]
        [TestCase(2, "Chaise", "Jolie table", 19.99, 4, "[\"image1\"]", "[\"style2\"]")]
        public async Task Update(int productId, string name, string description, decimal price, int quantity, string images, string styles)
        {
            CreateProduct newProduct = new()
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                Images = JsonSerializer.Deserialize<List<string>>(images)!,
                // Styles = JsonSerializer.Deserialize<List<string>>(styles)!
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/product/update/" + productId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(newProduct), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Product? result = await response.Content.ReadFromJsonAsync<Product>();
            Assert.NotNull(result);
            Assert.AreEqual(name, result!.Name);
            Assert.AreEqual(description, result!.Description);
            Assert.AreEqual(price, result!.Price);
            Assert.AreEqual(quantity, result!.Quantity);
            // Assert.AreEqual(images, result!.ImagesList);
            // Assert.AreEqual(styles, result!.StylesList);
        }

        [Order(4)]
        [TestCase(2)]
        public async Task Delete(int productId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/product/delete/" + productId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            string? result = await response.Content.ReadFromJsonAsync<string>();
            Assert.AreEqual("Product with id " + productId + " deleted", result);
        }
    }
}

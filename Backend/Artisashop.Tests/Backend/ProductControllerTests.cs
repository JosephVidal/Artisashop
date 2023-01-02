using Artisashop.Models;
using Artisashop.Models.ViewModel;
using Bogus.DataSets;
using NUnit.Framework;
using System;
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
    [TestFixture]
    public class ProductControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("john.artisan@artisashop.fr", "Artisashop@2022");
            _token = AccountControllerTest.token;
        }

        [Order(2)]
        [TestCase(TestName = "Load product list", Category = "List Success")]
        public async Task List()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/product?sellerId=1");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Product>? result = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.NotNull(result);
        }

        [Order(2)]
        [TestCase(1, TestName = "ProductInfo", Category = "Product Success")]
        [TestCase(6, "Product with id 6 not found", TestName = "Product not found", Category = "Product Fail")]
        public async Task Product(int id, string? expt = null)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/product/info/" + id);
            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Product? result = await response.Content.ReadFromJsonAsync<Product>();
                Assert.NotNull(result);
            }
            catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }

        [Order(1)]
        [TestCase("Table", "Jolie table", 39.99, 3, "[\"image1\",\"image2\"]", "[\"style1\",\"style2\"]", TestName = "Creating table", Category = "Create Success")]
        [TestCase("Chaise", "Jolie chaise", 19.99, 3, "[\"image1\",\"image2\"]", "[\"style1\",\"style2\"]", TestName = "Creating chaise", Category = "Create Success")]
        [TestCase("Lampe", "Jolie lampe", 19.99, 3, "[\"image1\",\"image2\"]", "[\"style1\",\"style2\"]", TestName = "Creating lampe", Category = "Create Success")]
        public async Task Create(string? name, string description, double price, int quantity, string images, string styles, string? expt = null)
        {
            CreateProduct newProduct = new()
            {
                Name = name,
                Description = description,
                Price = decimal.Parse(price.ToString()),
                Quantity = quantity,
                Images = JsonSerializer.Deserialize<List<string>>(images)!,
                Styles = JsonSerializer.Deserialize<List<string>>(styles)!
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
        }

        [Order(3)]
        [TestCase(2, "Chaise", "Jolie table", 19.99, 4, "[\"image1\"]", "[\"style2\"]", TestName = "Updating table", Category = "Update Success")]
        [TestCase(6, "Chaise", "Jolie table", 19.99, 4, "[\"image1\"]", "[\"style2\"]", "Product with id 6 not found", TestName = "Product 6 not found", Category = "Update Fail")]
        public async Task Update(int productId, string name, string description, double price, int quantity, string images, string styles, string? expt = null)
        {
            CreateProduct newProduct = new()
            {
                Name = name,
                Description = description,
                Price = decimal.Parse(price.ToString()),
                Quantity = quantity,
                Images = JsonSerializer.Deserialize<List<string>>(images)!,
                Styles = JsonSerializer.Deserialize<List<string>>(styles)!
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Patch, "api/product/update/" + productId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(newProduct), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                Product? result = await response.Content.ReadFromJsonAsync<Product>();
                Assert.NotNull(result);
                Assert.AreEqual(name, result!.Name);
                Assert.AreEqual(description, result!.Description);
                Assert.AreEqual(price, result!.Price);
                Assert.AreEqual(quantity, result!.Quantity);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }

        [Order(4)]
        [TestCase(2, TestName = "Delete product 2", Category = "Delete Success")]
        [TestCase(2, "Product with id 2 not found", TestName = "Product 2 not found", Category = "Delete Fail")]
        public async Task Delete(int productId, string? expt = null)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/product/delete/" + productId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                string? result = await response.Content.ReadFromJsonAsync<string>();
                Assert.AreEqual("Product with id " + productId + " deleted", result);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }
    }
}
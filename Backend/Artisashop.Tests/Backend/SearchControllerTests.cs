using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Artisashop.Models.ViewModel;
using Artisashop.Models;

namespace Artisashop.Tests.Backend
{
    [TestFixture]
    public class SearchControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();

        [TestCase("Table", null, "[]")]
        public async Task ProductSearch(string name, string job, string styles)
        {
            ProductSearch model = new()
            {
                Name = name,
                Job = job,
                Styles = JsonSerializer.Deserialize<List<string>>(styles),
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/search/product")
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Product>? result = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.NotNull(result);
            Assert.AreEqual("Table", result![0].Name);
        }

        [TestCase("John", null, null)]
        public async Task CraftsmanSearch(string? firstName, string? lastName, string? job)
        {
            CraftsmanSearch model = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Job = job
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/search/craftsman")
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Account>? result = await response.Content.ReadFromJsonAsync<List<Account>>();
            Assert.NotNull(result);
            Assert.AreEqual(firstName, result![0].Firstname);
        }
    }
}
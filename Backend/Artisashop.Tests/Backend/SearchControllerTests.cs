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

        [TestCase("Table", null, "[]", TestName = "Search Table", Category = "ProductSearch Success")]
        [TestCase(null, "Ebeniste", "[]", TestName = "Search Ebeniste product", Category = "ProductSearch Success")]
        [TestCase("Table", "Ebeniste", "[]", TestName = "Search Ebeniste Table", Category = "ProductSearch Success")]
        public async Task ProductSearch(string name, string job, string styles)
        {
            ProductSearch model = new()
            {
                Name = name,
                Job = job,
                Styles = JsonSerializer.Deserialize<List<string>>(styles),
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/search/product?Name=" + name + "&Job=" + job + "&Styles=" + styles)
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Product>? results = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.NotNull(results);
            foreach (var result in results!)
            {
                if (name != null)
                    Assert.AreEqual(name, result!.Name);
                if (job != null)
                    Assert.AreEqual(job, result!.Craftsman!.Job);
            }
        }

        [TestCase("John", null, null, TestName = "Search firstname John", Category = "CraftsmanSearch Success")]
        [TestCase(null, "Artisan", null, TestName = "Search lastname Artisan", Category = "CraftsmanSearch Success")]
        [TestCase("John", "Artisan", null, TestName = "Search fullname John Artisan", Category = "CraftsmanSearch Success")]
        [TestCase(null, null, "Ebeniste", TestName = "Search Ebenisite", Category = "CraftsmanSearch Success")]
        [TestCase("John", null, "Ebeniste", TestName = "Search Ebenisite firstname John", Category = "CraftsmanSearch Success")]
        [TestCase(null, "Artisan", "Ebeniste", TestName = "Search Ebenisite lastname Artisan", Category = "CraftsmanSearch Success")]
        [TestCase("John", "Artisan", "Ebeniste", TestName = "Search Ebenisite fullname John Artisan", Category = "CraftsmanSearch Success")]
        public async Task CraftsmanSearch(string? firstName, string? lastName, string? job)
        {
            CraftsmanSearch model = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Job = job
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/search/craftsman?FirstName=" + firstName + "LastName=" + lastName + "&Job=" + job)
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<Account>? results = await response.Content.ReadFromJsonAsync<List<Account>>();
            Assert.NotNull(results);
            foreach (var result in results!)
            {
                if (firstName != null)
                    Assert.AreEqual(firstName, result!.Firstname);
                if (lastName != null)
                    Assert.AreEqual(lastName, result!.Lastname);
                if (job != null)
                    Assert.AreEqual(job, result!.Job);
            }
        }
    }
}
using Artisashop.Tests;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Artisashop.Models;
using System.Net.Http.Json;
using Artisashop.Models.ViewModel;

namespace Artisashop.Tests.Backend
{
    public class HomeControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();

        [Test]
        public async Task Info()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/home");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Home? result = await response.Content.ReadFromJsonAsync<Home>();
            Assert.NotNull(result);
            Assert.AreEqual(2, result!.ProductSample.Count);
            Assert.AreEqual(1, result!.CraftsmanSample.Count);
            Assert.AreEqual(2, result!.ProductNumber);
            Assert.AreEqual(1, result!.CraftsmanNumber);
            Assert.AreEqual(2, result!.Inscrit);
        }
    }
}

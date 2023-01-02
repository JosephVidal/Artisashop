using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Artisashop.Models.ViewModel;

namespace Artisashop.Tests.Backend
{
    public class HomeControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();

        [TestCase(TestName = "Load stats", Category = "Info Success")]
        public async Task Info()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/home");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Home? result = await response.Content.ReadFromJsonAsync<Home>();
            Assert.NotNull(result);
            Assert.AreEqual(5, result!.ProductSample.Count);
            Assert.AreEqual(5, result!.CraftsmanSample.Count);
            Assert.AreEqual(27, result!.ProductNumber);
            Assert.AreEqual(10, result!.CraftsmanNumber);
            Assert.AreEqual(100, result!.Inscrit);
        }
    }
}

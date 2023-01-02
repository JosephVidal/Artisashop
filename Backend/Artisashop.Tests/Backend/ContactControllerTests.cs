using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Artisashop.Models.ViewModel;

namespace Artisashop.Tests.Backend
{
    [TestFixture]
    internal class ContactControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();

        [TestCase(TestName = "Index", Category = "Contact Success")]
        public static async Task Index()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/contact");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            Contact? result = await response.Content.ReadFromJsonAsync<Contact>();
            Assert.NotNull(result);
            Assert.AreEqual("Client", result!.ReceiverList[0]);
            Assert.AreEqual("Sales", result!.ReceiverList[1]);
        }

        [TestCase(TestName = "Send mail", Category = "Send Success")]
        public static async Task Send()
        {
            Contact? model = new Contact()
            {
                Subject = "Test contact",
                Email = "jean.epp@epitech.eu",
                Content = "Je suis très content",
                Receiver = "Client"
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/contact");
            postRequest.Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
        }
    }
}

using Backend.Models;
using Backend.Models.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Artisashop.Tests.Backend
{
    public class ChatControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;
        private List<string> _ids = new();

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jane.consumer@epitech.eu", "Password_1234");
            _token = AccountControllerTest.token;
            _ids = AccountControllerTest.ids;
        }

        [Order(2)]
        [Test]
        public async Task Index()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/chat/list");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<ChatPreview>? result = await response.Content.ReadFromJsonAsync<List<ChatPreview>>();
            Assert.NotNull(result);
        }

        [Order(1)]
        [TestCase("Un message")]
        [TestCase("Deux message")]
        [TestCase("Trois message")]
        public async Task Create(string message)
        {
            CreateChatMessage createChatMessage = new()
            {
                FromUserId = _ids[3],
                ToUserID = _ids[1],
                Content = message
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/chat");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(createChatMessage), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            ChatMessage? result = await response.Content.ReadFromJsonAsync<ChatMessage>();
            Assert.NotNull(result);
        }

        [Order(2)]
        [Test]
        public async Task LoadHistory()
        {
            ChatHistory val = new()
            {
                UserIDOne = _ids[3],
                UserIDTwo = _ids[1]
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/chat/history");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(val), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            List<ChatMessage>? result = await response.Content.ReadFromJsonAsync<List<ChatMessage>>();
            Assert.NotNull(result);
        }

        [Order(2)]
        [TestCase(1)]
        public async Task GetMsg(int msgId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/chat/" + msgId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            ChatMessage? result = await response.Content.ReadFromJsonAsync<ChatMessage>();
            Assert.NotNull(result);
        }

        [Order(3)]
        [TestCase(1)]
        public async Task DeleteMsg(int msgId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/chat/" + msgId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();

            string? result = await response.Content.ReadFromJsonAsync<string>();
            Assert.AreEqual("Message with id " + msgId + " deleted", result);
        }
    }
}

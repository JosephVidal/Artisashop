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
            await AccountControllerTest.Login("jane.consumer@artisashop.fr", "Artisashop@2022");
            _token = AccountControllerTest.token;
        }

        [Order(2)]
        [TestCase(TestName = "Index success", Category = "Index Success")]
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
        [TestCase("Un message", "1", "2",TestName = "Send one message", Category = "Create Success")]
        [TestCase("Deux message", "2", "1", TestName = "Send second message", Category = "Create Success")]
        [TestCase("Trois message", "1", "2", TestName = "Send third message", Category = "Create Success")]
        [TestCase("Quatre message", "kregoehgihih", "2", "Sender with id kregoehgihih not found", TestName = "Sender not found", Category = "Create Fail")]
        [TestCase("Quatre message", "1", "kregoehgihih", "Receiver with id kregoehgihih not found", TestName = "Receiver not found", Category = "Create Fail")]
        public async Task Create(string message, string? id1 = null, string? id2 = null, string? expt = "")
        {

            CreateChatMessage createChatMessage = new()
            {
                FromUserId = id1,
                ToUserID = id2,
                Content = message
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/chat");
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            postRequest.Content = new StringContent(JsonSerializer.Serialize(createChatMessage), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);
            try
            {
                response.EnsureSuccessStatusCode();

                ChatMessage? result = await response.Content.ReadFromJsonAsync<ChatMessage>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control(expt!, response);
            }
        }

        [Order(2)]
        [TestCase("1", "2", TestName = "Load current user history", Category = "LoadHistory Success")]
        public async Task LoadHistory(string id1, string id2)
        {
            ChatHistory val = new()
            {
                UserIDOne = id1,
                UserIDTwo = id2
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
        [TestCase(1, TestName = "Get message", Category = "GetMsg Success")]
        [TestCase(8, TestName = "Message to update not found", Category = "GetMsg Fail")]
        public async Task GetMsg(int msgId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Get, "api/chat/" + msgId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);

            try
            {
                response.EnsureSuccessStatusCode();

                ChatMessage? result = await response.Content.ReadFromJsonAsync<ChatMessage>();
                Assert.NotNull(result);
            } catch (Exception)
            {
                Common.Control("Message with id " + msgId + " not found", response);
            }
        }

        [Order(3)]
        [TestCase(1, TestName = "Message deleted", Category = "DeleteMsg Success")]
        [TestCase(1, TestName = "Message to delete not found", Category = "DeleteMsg Fail")]
        public async Task DeleteMsg(int msgId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "api/chat/" + msgId);
            postRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await _client.SendAsync(postRequest);
            try
            {
                response.EnsureSuccessStatusCode();

                string? result = await response.Content.ReadFromJsonAsync<string>();
                Assert.AreEqual("Message with id " + msgId + " deleted", result);
            } catch (Exception)
            {
                Common.Control("Message with id " + msgId + " not found", response);
            }
        }
    }
}

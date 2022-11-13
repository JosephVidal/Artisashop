/*using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;


namespace Artichaut.Tests.FrontEnd
{
    [TestFixture]
    public class ChatTest
    {
        public AuthenticationTest AuthenticationTest { get; private set; }
        public IWebDriver? Driver { get; set; }
        public IJavaScriptExecutor? Js { get; private set; }

        public ChatTest()
        {
            AuthenticationTest = new AuthenticationTest();
            Driver = AuthenticationTest.Driver;
            Js = AuthenticationTest.Js;
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            AuthenticationTest.SetUp();
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            AuthenticationTest.TearDown();
        }

        [Test]
        public void Chat()
        {
            AuthenticationTest.Login("client.client@gmail.com", "password");
            AuthenticationTest.Driver!.Navigate().GoToUrl("http://artisashop:80/chat/OFwRBejfzp/");
            AuthenticationTest.Driver.FindElement(By.Id("messageInput")).SendKeys("bonjour");
            AuthenticationTest.Driver.FindElement(By.Id("sendButton")).Submit();
            Thread.Sleep(2000);
            AuthenticationTest.Driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/ul/li"));
            Assert.That(AuthenticationTest.Driver, Is.Not.Null);
        }

        /*[Test]
        [Order(5)]
        public void ChatList()
        {
            authenticationTest.driver.Navigate().GoToUrl("http://artisashop:80/chat/list/");
            Console.WriteLine(authenticationTest.driver.Title);

            authenticationTest.driver.FindElement(By.CssSelector(".bi-chat-dots-fill")).Click();
            if (authenticationTest.driver.Title != "Chat - Artisashop")
                Assert.Fail();
        }
    }
}
*/
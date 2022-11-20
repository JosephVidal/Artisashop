/*using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace Artichaut.Tests.FrontEnd
{
    [TestFixture]
    public class AuthenticationTest
    {
        public IWebDriver? Driver { get; private set; }
        public IJavaScriptExecutor? Js { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            //TODO Env variable SELENIUM_HUB_ADDR
            string isContained = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true" ? "selenium-hub" : "localhost";
            Driver = new RemoteWebDriver(new Uri("http://" + isContained + ":4444/wd/hub"), new ChromeOptions().ToCapabilities());
            Js = (IJavaScriptExecutor)Driver;
            //TODO Env variable to clean WEBSITE_ADDR
            Driver.Manage().Cookies.DeleteCookieNamed("currentUser");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver!.Quit();
        }

        [Test]
        [Order(1)]
        public void RegisterFail()
        {
            //TODO env variable
            Driver!.Navigate().GoToUrl("http://artichaut:80/");
            Driver.FindElement(By.CssSelector(".bi-person-fill")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Driver.FindElement(By.LinkText("Register")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Register - Artichaut"));
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[3]/button")).Click();
            Thread.Sleep(2000);
            Driver.SwitchTo().ActiveElement();
            Driver.FindElement(By.Id("accept")).Click();
            Driver.FindElement(By.Id("send")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Register - Artichaut"));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[1]/div[1]/span")).GetAttribute("innerText"), Is.EqualTo("The FirstName field is required."));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[1]/div[2]/span")).GetAttribute("innerText"), Is.EqualTo("The LastName field is required."));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/span[1]")).GetAttribute("innerText"), Is.EqualTo("The Email field is required."));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[2]/div[1]/span")).GetAttribute("innerText"), Is.EqualTo("The Password field is required."));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[2]/div[2]/span")).GetAttribute("innerText"), Is.EqualTo("The PasswordConfirm field is required."));
            Driver.FindElement(By.Id("Email")).SendKeys("notvalidemail");
            Driver.FindElement(By.Id("Password")).SendKeys("1234");
            Driver.FindElement(By.Id("PasswordConfirm")).SendKeys("1243");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[3]/button")).Click();
            Thread.Sleep(2000);
            Driver.SwitchTo().ActiveElement();
            Driver.FindElement(By.Id("accept")).Click();
            Driver.FindElement(By.Id("send")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Register - Artichaut"));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/span[1]")).GetAttribute("innerText"), Is.EqualTo("The Email field is not a valid e-mail address."));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[2]/div[2]/span")).GetAttribute("innerText"), Is.EqualTo("'PasswordConfirm' and 'Password' do not match."));
        }

        [Test]
        [Order(2)]
        public void RegisterConsummer()
        {
            //TODO env variable
            Driver!.Navigate().GoToUrl("http://Artichaut:80/");
            Driver.FindElement(By.CssSelector(".bi-person-fill")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Driver.FindElement(By.LinkText("Register")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Register - Artichaut"));
            Driver.FindElement(By.Id("FirstName")).SendKeys("Jean");
            Driver.FindElement(By.Id("LastName")).SendKeys("EPP");
            Driver.FindElement(By.Id("Email")).SendKeys("jeanepp99@gmail.com");
            Driver.FindElement(By.Id("Password")).SendKeys("password");
            Driver.FindElement(By.Id("PasswordConfirm")).SendKeys("password");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[1]/form/div[3]/button")).Click();
            Thread.Sleep(2000);
            Driver.SwitchTo().ActiveElement();
            Driver.FindElement(By.Id("accept")).Click();
            Driver.FindElement(By.Id("send")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
        }

        [Order(2)]
        public void RegisterCraftsman()
        {
            //TODO env variable
            Driver!.Navigate().GoToUrl("http://Artichaut:80/");
            Driver.FindElement(By.CssSelector(".bi-person-fill")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Driver.FindElement(By.LinkText("Register")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Register - Artichaut"));
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[2]/a")).Click();
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/div[1]/div[1]/input")).SendKeys("artisan");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/div[1]/div[2]/input")).SendKeys("test");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/input")).SendKeys("artisan.test@gmail.com");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/div[2]/div[1]/input")).SendKeys("password");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/div[2]/div[2]/input")).SendKeys("password");
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/div[3]/button")).Click();
            Thread.Sleep(2000);
            Driver.SwitchTo().ActiveElement();
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/button[2]")).Click();
            Driver.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/form/span[2]/button")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
        }

        [Test]
        [Order(3)]
        public void LoginFail()
        {
            //TODO env variable
            Driver!.Navigate().GoToUrl("http://Artichaut:80/");
            Driver.FindElement(By.CssSelector(".bi-person-fill")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Driver.FindElement(By.CssSelector(".btn-block")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/span[1]")).GetAttribute("innerText"), Is.EqualTo("The Email field is required."));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/span[2]")).GetAttribute("innerText"), Is.EqualTo("The Password field is required."));
            Driver.FindElement(By.Id("Email")).SendKeys("notvalidemail");
            Driver.FindElement(By.CssSelector(".btn-block")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Assert.That(Driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/span[1]")).GetAttribute("innerText"), Is.EqualTo("The Email field is not a valid e-mail address."));
        }

        [TestCase("client.client@gmail.com", "password")]
        [Order(4)]
        public void Login(string login, string password)
        {
            //TODO env variable
            Driver!.Navigate().GoToUrl("http://Artichaut:80/");
            Driver.FindElement(By.CssSelector(".bi-person-fill")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
            Driver.FindElement(By.Id("Email")).SendKeys(login);
            Driver.FindElement(By.Id("Password")).SendKeys(password);
            Driver.FindElement(By.CssSelector(".btn-block")).Click();
            Thread.Sleep(2000);
            Assert.That(Driver.Title, Is.EqualTo("Home - Artichaut"));
        }

        [Test]
        [Order(5)]
        public void Logout()
        {
            Driver!.Navigate().GoToUrl("http://Artichaut:80/");
            Driver.FindElement(By.CssSelector(".bi-person-fill")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Account - Artichaut"));
            Js!.ExecuteScript("arguments[0].scrollIntoView(true);", Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/button")));
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/button")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
        }

        [Test]
        [Order(6)]
        public void DeleteAccount()
        {
            //TODO env variable
            Login("baby.artisan@gmail.com", "password");
            Driver!.Navigate().GoToUrl("http://Artichaut:80/account");
            Js!.ExecuteScript("arguments[0].scrollIntoView(true);", Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[3]/a")));
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[3]/a")).Click();
            Assert.That(Driver.Title, Is.EqualTo("Login - Artichaut"));
        }
    }
}*/
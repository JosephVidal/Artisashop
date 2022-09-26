using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Artichaut.Models;
using Artichaut.Controllers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Artichaut.Tests.Backend
{
    [TestFixture]
    public class SearchControllerTests
    {
        public static readonly HttpClient _client = new TestingWebAppFactory<Program>().CreateClient();
        private string? _token;

        [OneTimeSetUp]
        public async Task SetUp()
        {
            await AccountControllerTest.Login("jean.epp@epitech.eu", "Password_1234");
            _token = AccountControllerTest.token;
        }

        /*[TestCase("jean.epp@epitech.eu", Account.UserType.CRAFTSMAN, "R:Token", "", "Ok")]
        public void ProductSearchExist(string objectId, Account.UserType type, string rights, object viewName, string returnType)
        {
            //if (returnType == "Ok")
            //    _mockProductRepo!.Setup(repo => repo.GetSearchList("Table", null, null)).ReturnsAsync(new List<Product> { new("Table", ) { Name = "Table" } }).Verifiable();

            SearchController search = new(_db!.Object);
            dynamic result = search.ProductSearch(new List<string>(), "Table");

            CommonTest.Control(_mocks!, result, viewName, returnType);
            Assert.True(result.Value[0].Name == "Table");
        }

        [TestCase("jean.epp@epitech.eu", Account.UserType.CRAFTSMAN, "R:Token", "", "Ok")]
        public void ProductSearchNotExist(string objectId, Account.UserType type, string rights, object viewName, string returnType)
        {
            if (returnType == "Ok")
                _mockProductRepo!.Setup(repo => repo.GetSearchList(null, null, null)).ReturnsAsync(new List<Product>()).Verifiable();

            SearchController search = new(_db!.Object);
            dynamic result = search.ProductSearch(new List<string>());

            CommonTest.Control(_mocks!, result, viewName, returnType);
            Assert.True(result.Value.Count == 0);
        }

        [TestCase("jean.epp@epitech.eu", Account.UserType.CRAFTSMAN, "R:Token", "", "Ok")]
        public void CraftsmanSearchExist(string objectId, Account.UserType type, string rights, object viewName, string returnType)
        {
            Account account = new("Artisan", "Jane", Account.UserType.CRAFTSMAN, "Brouteur")
            {
                Email = "jane.artisan@gmail.com"
            };

            if (returnType == "Ok")
                _mockAccountCraftsmanRepo!.Setup(repo => repo.SearchCraftsman("Jane", null)).Returns(new List<Account>() { account }).Verifiable();

            SearchController search = new(_db!.Object);
            dynamic result = search.CraftsmanSearch("Jane");

            CommonTest.Control(_mocks!, result, viewName, returnType);
            Assert.True(result.Value[0].Username == "jane.artisan@gmail.com");
        }

        [TestCase("jean.epp@epitech.eu", Account.UserType.CRAFTSMAN, "R:Token", "", "Ok")]
        public void CraftsmanSearchNotExist(string objectId, Account.UserType type, string rights, object viewName, string returnType)
        {
            if (returnType == "Ok")
                _mockAccountCraftsmanRepo!.Setup(repo => repo.SearchCraftsman("Richard", null)).Returns(new List<Account>()).Verifiable();

            SearchController search = new(_db!.Object);
            dynamic result = search.CraftsmanSearch("Richard");

            CommonTest.Control(_mocks, result, viewName, returnType);
            Assert.True(result.Value.Count == 0);
        }*/
    }
}
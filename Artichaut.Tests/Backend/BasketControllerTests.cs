/*using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Artichaut.Interfaces.IRepository;
using Artichaut.Interfaces.IService;
using Artichaut.Models;
using Artichaut.Controllers;
using Artichaut.Repositories;
using static Artichaut.Models.Account;
using Artichaut.Models.ViewModel;
using static Artichaut.Models.Basket;
using System;
using System.Linq;

namespace Artichaut.Tests.Backend
{
    [TestFixture]
    public class BasketControllerTests
    {
        Mock<IAccountRepository>? _mockAccountRepo;
        Mock<IBasketRepository>? _mockBasketRepo;
        Mock<IProductRepository>? _mockProductRepo;
        Mock<IMailService>? _mockMailService;
        Mock<StoreDbContext>? _db;
        Mock[]? _mocks;

        [SetUp]
        public void InitTest()
        {
            _mocks = new Mock[] {
                _mockAccountRepo = new Mock<IAccountRepository>(),
                _mockBasketRepo = new Mock<IBasketRepository>(),
                _mockProductRepo = new Mock<IProductRepository>(),
                _mockMailService = new Mock<IMailService>(),
                _db = new Mock<StoreDbContext>()
            };
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "Index", "View")]
        public async Task Index(string userId, string viewName, string returnType)
        {;
            if (returnType == "View")
                _mockBasketRepo!.Setup(repo => repo.GetBasketForUser(userId, true)).Returns(new List<Basket>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.Index();

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "Empty basket", "ViewError", true)]
        [TestCase("jean.epp@epitech.eu", "DeliveryInfo", "View")]
        public async Task DeliveryInfo(string userId, string viewName, string returnType, bool empty = false)
        {
            if (empty)
                _mockBasketRepo!.Setup(repo => repo.GetBasketForUser(userId, true)).Returns(new List<Basket>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.DeliveryInfo();

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "Bad address", "BadRequest")]
        [TestCase("jean.epp@epitech.eu", "Payement", "Ok", "3 All. des Centaurées, 38240 Meylan")]
        public async Task Payement(string viewName, string returnType, string address)
        {
            _mockBasketRepo!.Setup(repo => repo.GetBasketForUser(It.IsAny<string>(), true)).Returns(new List<Basket>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.Payement(address);

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "", "Ok")]
        public async Task ListJSON(string userId, string viewName, string returnType)
        {
            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.GetBasketForUser(userId, It.IsAny<bool>())).Returns(new List<Basket>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.ListJSON();

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "", "Ok")]
        public async Task ModifyItemDeliveryOpt(string userId, string viewName, string returnType)
        {
            int productID = 0;
            DeliveryOption deliveryOption = DeliveryOption.DELIVERY;

            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.ModifyProductDeliveryOptToUser(userId, productID, deliveryOption)).ReturnsAsync(deliveryOption).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            dynamic result = await basketController.ModifyItemDeliveryOpt(productID, deliveryOption);

            CommonTest.Control(_mocks!, result, viewName, returnType);
            if (returnType == "Ok")
                Assert.IsTrue("{deliveryOpt:" + deliveryOption + "}" == result.Value);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "", "Ok")]
        public void DeleteItem(string userId, string viewName, string returnType)
        {
            int productID = 0;

            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.DeleteProductQuantityToUser(userId, productID)).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = basketController.DeleteItem(productID).Result;

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "", "Ok")]
        public async Task BasketToPaypalBill(string userId, string viewName, string returnType)
        {
            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.GetBasketForUser(userId, It.IsAny<bool>())).Returns(new List<Basket>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.BasketToPaypalBill();

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "", "Ok")]
        public async Task BasketSold(string userId, string viewName, string returnType)
        {
            Account? account = returnType == "ContentResult" ? new("Epp", "Jean", UserType.CONSUMER, "Brouteur")
            {
                Email = "jean.epp@epitech.eu"
            } : null;

            if (returnType == "Ok")
            {
                _mockBasketRepo!.Setup(repo => repo.GetBasketForUser(userId, It.IsAny<bool>())).Returns(new List<Basket>()).Verifiable();
                _mockAccountRepo!.Setup(repo => repo.GetById(userId)).ReturnsAsync(account).Verifiable();
            }

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.BasketSold();

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "CraftsmanCmdList", "Ok")]
        public async Task CraftsmanCmdList(string userId, string viewName, string returnType)
        {
            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.GetAllForCraftsman(userId)).Returns(new List<Basket>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.CraftsmanCmdList();

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase("Login", "Redirect")]
        [TestCase("", "Ok")]
        public async Task CmdChangeStatus(object viewName, string returnType)
        {
            int basketID = 0;
            State state = State.END;

            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.ModifyCurrentState(basketID, state)).ReturnsAsync(state).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.CmdChangeStatus(basketID, state);

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "CreateCustomCmd", "Ok")]
        public async Task CreateCustomCmd(string userId, string viewName, string returnType)
        {
            Account account = new("test", "account", UserType.CRAFTSMAN, "Brouteur")
            {
                Email = "account@test.com"
            };

            if (returnType == "Ok")
                _mockAccountRepo!.Setup(repo => repo.GetById(userId)).ReturnsAsync(account).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.CreateCustomCmd(userId);

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "Chat", "Redirect")]
        public async Task PostCreateCustomCmd(string userId, string viewName, string returnType)
        {
            CreateCustomCmdViewModel CCCVM = new("00001", "Test product", "This is a test", 1);

            if (returnType == "Ok")
                _mockBasketRepo!.Setup(repo => repo.CreateCustomCmd(userId, CCCVM.CraftsmanID, CCCVM.Name, CCCVM.Desc, CCCVM.Quantity)).ReturnsAsync(new List<Dictionary<string, string>>()).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.PostCreateCustomCmd(CCCVM);

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase("Login", "Redirect")]
        [TestCase("UpdateCustomCmd", "View")]
        public async Task UpdateCustomCmd(string viewName, string returnType)
        {
            Account account = new("test", "account", UserType.CRAFTSMAN, "Brouteur")
            {
                Email = "account@test.com"
            };
            Product product = new("Table", account);
            Basket basket = new(account, product, 1, DeliveryOption.TAKEOUT, State.WAITINGCONSUMER, Enum.GetValues(typeof(State)).Cast<State>().ToList());

            if (returnType == "Ok")
            {
                //_mockBasketRepo!.Setup(repo => repo.GetItem("classes/Basket/" + basket.ObjectId, cookie.SessionToken, It.IsAny<bool>())).ReturnsAsync(basket).Verifiable();
                _mockProductRepo!.Setup(repo => repo.GetById(product.Id)).ReturnsAsync(product).Verifiable();
                _mockAccountRepo!.Setup(repo => repo.GetById(account.Id)).ReturnsAsync(account).Verifiable();
            }

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.UpdateCustomCmd(basket.Id);

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }

        [TestCase(null, "Login", "Redirect")]
        [TestCase("jean.epp@epitech.eu", "Chat", "Redirect")]
        public async Task PostUpdateCustomCmd(string objectId, object viewName, string returnType)
        {
            Account account = new("test", "account", UserType.CRAFTSMAN, "Brouteur")
            {
                Email = "account@test.com",
            };
            Product product = new("Table", account);
            Basket basket = new(account, product, 1, DeliveryOption.TAKEOUT, State.WAITINGCONSUMER, Enum.GetValues(typeof(State)).Cast<State>().ToList());

            if (returnType == "Redirect" && objectId != null)
                _mockBasketRepo!.Setup(repo => repo.UpdateCustomCmd(basket)).ReturnsAsync(basket).Verifiable();

            BasketController basketController = new(_mockMailService!.Object, _db!.Object);
            var result = await basketController.PostUpdateCustomCmd(basket);

            CommonTest.Control(_mocks!, result, viewName, returnType);
        }
    }
}*/
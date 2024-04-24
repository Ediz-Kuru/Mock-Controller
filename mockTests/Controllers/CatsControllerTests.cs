using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mock.depart.Controllers;
using mock.depart.Models;
using mock.depart.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace mock.depart.Controllers.Tests
{
    [TestClass()]
    public class CatsControllerTests
    {
        private Mock<CatsService> catsServiceMock;
        private Mock<CatsController> catsControllerMock;
        //Mock<ControllerBase> controllerBaseMock;

        public CatsControllerTests()
        {
            catsServiceMock = new Mock<CatsService>();
            catsControllerMock = new Mock<CatsController>(catsServiceMock.Object) { CallBase = true };
            //controllerBaseMock = new Mock<ControllerBase>();
        }

        [TestCleanup] public void Cleanup()
        {
            catsControllerMock.Reset();
            catsServiceMock.Reset();
            //controllerBaseMock.Reset();
        }

        [TestMethod()]
        public void DeleteCatTest()
        {
            catsControllerMock.Setup(x => x.UserId).Returns("Chat");
            catsServiceMock.Setup(x => x.Get(It.IsAny<int>())).Returns((Cat?)null);

            /*Cat? cat = catsServiceMock.Object.Get(0);
            Assert.IsNull(cat);*/
            var actionResult = catsControllerMock.Object.DeleteCat(0);

            var result = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextCheckerMachine.Controllers;

namespace TextCheckerMachine.Tests.Controllers
{
    class ErrorControllerTest
    {
        [TestClass]
        public class HomeControllerTest
        {
            private ErrorController _errorController;

            [TestInitialize]
            public void TestInitialize()
            {
                _errorController = new ErrorController();
            }

            [TestMethod]
            public void PageNotFound_Test()
            {
                // Act
                ViewResult result = _errorController.NotFound() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public void Forbidden_Test()
            {
                // Act
                ViewResult result = _errorController.Forbidden() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
        }
    }
}

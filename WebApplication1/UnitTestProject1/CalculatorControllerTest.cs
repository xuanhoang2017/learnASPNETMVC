using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestAuthor()
        {
            var controller = new CalculatorController();
            var result = controller.ShowAuthor();

            Assert.AreEqual("Vu Xuan Hoang", result);
        }
    }
}

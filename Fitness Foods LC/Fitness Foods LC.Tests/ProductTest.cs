using Fitness_Foods_LC.Controllers;
using Fitness_Foods_LC.Enumeradores;
using Fitness_Foods_LC.Interfaces;
using Fitness_Foods_LC.Models;
using Fitness_Foods_LC.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using org.bouncycastle.mail.smime.handlers;
using System.Web.Mvc;

namespace Fitness_Foods_LC.Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GetCodeTest()
        {
            // Arrange
            var productRepository = new Mock<IProductRepository>();
            
            Product product = new Product();
            product.Code = "12345";

            productRepository.Setup(x => x.GetProduct(It.IsAny<Product>()))

            // Act


            // Assert
        }


        [TestMethod]
        public void GetProductsTest()
        {
            var controller = new HomeController();
            var result = controller.GetProducts();
            Assert.IsNotNull(result);
        }


}
}
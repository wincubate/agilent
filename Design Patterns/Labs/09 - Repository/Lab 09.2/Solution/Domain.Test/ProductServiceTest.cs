using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Wincubate.RepositoryLabs.Domain.Interfaces;

namespace Wincubate.RepositoryLabs.Domain.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void Test_ProductService_ReturnsCorrectDictionary_Ok()
        {
            // Arrange
            IProductRepository repository = new FakeProductRepository(
                new Product { Id = 1, Name = "Kandarian Dagger", Manufacturer = "Ruby", Category = Category.Hardware },
                new Product { Id = 2, Name = "Necronomicon Ex Mortis", Manufacturer = "Deadites Press", Category = Category.Book },
                new Product { Id = 3, Name = "How to become a Brujo", Manufacturer = "Ghost Beaters", Category = Category.Book }
            );

            ProductService productService = new ProductService(repository);

            // Act
            IDictionary<Category?, int> actual = productService.ComputeGroupCounts();

            // Assert
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(actual[Category.Book], 2);
            Assert.AreEqual(actual[Category.Hardware], 1);
        }
    }
}
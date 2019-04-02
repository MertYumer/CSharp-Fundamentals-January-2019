namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            IProduct product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        public void Constructor_InvalidLabel_ShouldThrowArgumentNullException()
        {
            string invalidLabel = string.Empty;
            decimal price = 12.50m;
            int quantity = 3;

            IProduct product;

            Assert.Throws<ArgumentNullException>(() 
                => product = new Product(invalidLabel, price, quantity),
                "Label must be at least 1 character long.");
        }

        [Test]
        public void Constructor_InvalidPrice_ShouldThrowArgumentException()
        {
            string label = "ABC";
            decimal invalidPrice = 0;
            int quantity = 3;

            IProduct product;

            Assert.Throws<ArgumentException>(()
                => product = new Product(label, invalidPrice, quantity),
                "Price must be greater than zero.");
        }

        [Test]
        public void Constructor_InvalidQuantity_ShouldThrowArgumentException()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int invalidQuantity = -2;

            IProduct product;

            Assert.Throws<ArgumentException>(()
                => product = new Product(label, price, invalidQuantity),
                "Quantity must be greater than zero.");
        }

        [Test]
        public void CompareTo_ShouldReturnTheGreaterAsciiCodeSum()
        {
            var greaterProduct = new Product("DEF", 1.5m, 2);
            var smallerProduct = new Product("ABC", 2.5m, 4);

            var expectedResult = 1;
            var actualResult = greaterProduct.CompareTo(smallerProduct);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
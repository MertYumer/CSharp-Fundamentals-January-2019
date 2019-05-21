namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();
        }

        [Test]
        public void Constructor_ShouldInitializeTheList()
        {
            var expectedResult = 0;
            var actualResult = this.productStock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_ShouldAddNonExistingProduct()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            var expectedResult = 1;
            var actualResult = this.productStock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_ShouldIncreaseQuantityOfExistingProduct()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var firstProduct = new Product(label, price, quantity);
            var secondProduct = new Product(label, price, quantity);
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            var expectedResult = 6;
            var actualResult = this.productStock[0].Quantity;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetProduct_AtInvalidIndex_ShouldThrowIndexOutOfRangeException()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            int invalidIndex = this.productStock.Count;
            IProduct searchedProduct;

            Assert.Throws<IndexOutOfRangeException>(() =>
            searchedProduct = this.productStock[invalidIndex],
            $"Invalid index: {invalidIndex}");
        }

        [Test]
        public void GetProduct_AtValidIndex_ShouldReturnTheCorrectProduct()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            int index = 0;
            var expectedProduct = product;
            var actualProduct = this.productStock[index];

            Assert.AreSame(expectedProduct, actualProduct);
        }

        [Test]
        public void SetProduct_AtInvalidIndex_ShouldThrowIndexOutOfRangeException()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            int invalidIndex = this.productStock.Count;

            Assert.Throws<IndexOutOfRangeException>(()
                => this.productStock[invalidIndex] = product,
                $"Invalid index: {invalidIndex}");
        }

        [Test]
        public void SetProduct_AtValidIndex_ShouldSetCorrectly()
        {
            string firstLabel = "ABC";
            decimal firstPrice = 12.50m;
            int firstQuantity = 3;
            string secondLabel = "DEF";
            decimal secondPrice = 14.50m;
            int secondQuantity = 2;

            var firstProduct = new Product(firstLabel, firstPrice, firstQuantity);
            var secondProduct = new Product(secondLabel, secondPrice, secondQuantity);
            this.productStock.Add(firstProduct);

            this.productStock[0] = secondProduct;

            var expectedProduct = secondProduct;
            var actualProduct = this.productStock[0];

            Assert.AreSame(expectedProduct, actualProduct);
        }

        [Test]
        public void Contains_ShouldReturnTrueIfTheProductExists()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            var expectedResult = true;
            var actualResult = this.productStock.Contains(product);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Contains_ShouldReturnFalseIfTheProductDoesNotExist()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);

            var expectedResult = false;
            var actualResult = this.productStock.Contains(product);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_NonExistingProduct_ShouldReturnFalse()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);

            var expectedResult = false;
            var actualResult = this.productStock.Remove(product);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_ExistingProduct_ShouldReturnTrue()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            var expectedResult = true;
            var actualResult = this.productStock.Remove(product);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_ExistingProduct_ShouldRemoveCorrectly()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);
            this.productStock.Remove(product);

            var expectedResult = 0;
            var actualResult = this.productStock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Find_AtInvalidIndex_ShouldThrowIndexOutOfRangeException()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            int invalidIndex = this.productStock.Count;

            IProduct searchedProduct;

            Assert.Throws<IndexOutOfRangeException>(() =>
            searchedProduct = this.productStock.Find(invalidIndex),
            $"Invalid index: {invalidIndex}");
        }

        [Test]
        public void Find_AtValidIndex_ShouldReturnTheCorrectProduct()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);

            int index = 0;
            var expectedProduct = product;
            var actualProduct = this.productStock.Find(index);

            Assert.AreSame(expectedProduct, actualProduct);
        }

        [Test]
        public void FindAllByPrice_NonExistingPrice_ShouldReturnEmptyCollection()
        {
            decimal searchedPrice = 12.50m;

            var expectedResult = 0;
            var actualResult = this.productStock.FindAllByPrice(searchedPrice).ToList().Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindAllByPrice_ExistingPrice_ShouldReturnTheCorrectProducts()
        {
            string firstLabel = "ABC";
            decimal firstPrice = 12.50m;
            int firstQuantity = 3;
            string secondLabel = "DEF";
            decimal secondPrice = 14.50m;
            int secondQuantity = 2;

            var firstProduct = new Product(firstLabel, firstPrice, firstQuantity);
            var secondProduct = new Product(secondLabel, secondPrice, secondQuantity);
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            decimal searchedPrice = 12.50m;

            var result = this.productStock.FindAllByPrice(searchedPrice).ToList();

            Assert.That(result.Contains(firstProduct));
            Assert.That(result.Count == 1);
        }

        [Test]
        public void FindAllByQuantity_NonExistingQuantity_ShouldReturnEmptyCollection()
        {
            int searchedQuantity = 3;

            var expectedResult = 0;
            var actualResult = this.productStock.FindAllByQuantity(searchedQuantity).ToList().Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindAllByQuantity_ExistingQuantity_ShouldReturnTheCorrectProducts()
        {
            string firstLabel = "ABC";
            decimal firstPrice = 12.50m;
            int firstQuantity = 3;
            string secondLabel = "DEF";
            decimal secondPrice = 14.50m;
            int secondQuantity = 2;

            var firstProduct = new Product(firstLabel, firstPrice, firstQuantity);
            var secondProduct = new Product(secondLabel, secondPrice, secondQuantity);
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            int searchedQuantity = 2;

            var result = this.productStock.FindAllByQuantity(searchedQuantity).ToList();

            Assert.That(result.Contains(secondProduct));
            Assert.That(result.Count == 1);
        }

        [Test]
        public void FindByLabel_NonExistingLabel_ShouldThrowArgumentException()
        {
            string searchedLabel = "ABC";

            Assert.Throws<ArgumentException>(() 
                => this.productStock.FindByLabel(searchedLabel)
                , "Label doesn't exist in the product stock.");
        }

        [Test]
        public void FindByLabel_ExistingLabel_ShouldReturnTheCorrectProduct()
        {
            string label = "ABC";
            decimal price = 12.50m;
            int quantity = 3;

            var product = new Product(label, price, quantity);
            this.productStock.Add(product);
            string searchedLabel = "ABC";

            var expectedResult = product;
            var actualResult = this.productStock.FindByLabel(searchedLabel);

            Assert.AreSame(expectedResult, actualResult);
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldReturnTheProductWithHighestPrice()
        {
            string firstLabel = "ABC";
            decimal firstPrice = 12.50m;
            int firstQuantity = 3;
            string secondLabel = "DEF";
            decimal secondPrice = 14.50m;
            int secondQuantity = 2;

            var firstProduct = new Product(firstLabel, firstPrice, firstQuantity);
            var secondProduct = new Product(secondLabel, secondPrice, secondQuantity);
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            var expectedResult = secondProduct;
            var actualResult = this.productStock.FindMostExpensiveProduct();

            Assert.AreSame(expectedResult, actualResult);
        }

        [Test]
        public void FindMostExpensiveProduct_FromEmptyCollection_ShouldThrowInvalidOperationException()
        {
            IProduct mostExpensiveProduct;

            Assert.Throws<InvalidOperationException>(() 
                => mostExpensiveProduct = this.productStock.FindMostExpensiveProduct(),
                "There are no products in the stock.");
        }

        [Test]
        public void FindAllInRange_ShouldReturnAllProductsBetweenTheGivenRangeInReversedOrder()
        {
            string firstLabel = "ABC";
            decimal firstPrice = 9.50m;
            int firstQuantity = 3;
            string secondLabel = "DEF";
            decimal secondPrice = 14.50m;
            int secondQuantity = 2;
            string thirdLabel = "GHI";
            decimal thirdPrice = 16.50m;
            int thirdQuantity = 5;

            var firstProduct = new Product(firstLabel, firstPrice, firstQuantity);
            var secondProduct = new Product(secondLabel, secondPrice, secondQuantity);
            var thirdProduct = new Product(thirdLabel, thirdPrice, thirdQuantity);
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdProduct);

            decimal lowerPrice = 10.40m;
            decimal higherPrice = 15.40m;

            var result = this.productStock
                .FindAllInRange(lowerPrice, higherPrice)
                .ToList();

            Assert.That(result.Contains(secondProduct));
            Assert.That(result.Count == 1);
        }

        [Test]
        public void FindAllInRange_InEmptyStock_ShouldReturnEmptyCollection()
        {
            decimal lowerPrice = 10.40m;
            decimal higherPrice = 15.40m;

            var expectedResult = 0;
            var actualResult = this.productStock
                .FindAllInRange(lowerPrice, higherPrice)
                .ToList()
                .Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

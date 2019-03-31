namespace P03_CustomLinkedList.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CustomLinkedListTests
    {
        private DynamicList<int> linkedList;

        [SetUp]
        public void SetUp()
        {
            this.linkedList = new DynamicList<int>();
        }

        [Test]
        public void AddMethodShouldAddElement()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(2);
            this.linkedList.Add(3);

            int expectedCount = 3;
            int actualCount = 3;

            Assert.AreEqual(expectedCount, actualCount,
                "Add method doesn't add element correctly!");
        }

        [Test]
        public void CountPropertyShouldReturnTheNumberOfElements()
        {
            int expectedCount = 3;
            int actualCount = this.linkedList.Count;

            Assert.AreEqual(expectedCount, actualCount,
                "Count returns wrong value!");
        }

        [Test]
        public void GetElementFromValidIndexShouldReturnTheCorrectValue()
        {
            int expectedValue = 3;
            int actualValue = this.linkedList[this.linkedList.Count - 1];

            Assert.AreEqual(expectedValue, actualValue, 
                "Get element doesn't return the correct value!");
        }

        [Test]
        public void GetElementFromInValidIndexShouldThrowException()
        {
            int invalidIndex = -1;

            Assert.That(this.linkedList[invalidIndex], Throws.ArgumentException,
                "Invalid index: " + invalidIndex);
        }
    }
}
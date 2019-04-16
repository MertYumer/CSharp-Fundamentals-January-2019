namespace P03_CustomLinkedList.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class CustomLinkedListTests
    {
        private DynamicList<int> linkedList;

        [SetUp]
        public void SetUp()
        {
            this.linkedList = new DynamicList<int>();
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void Add_ShouldAddElement(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int expectedCount = 3;
            int actualCount = 3;

            Assert.AreEqual(expectedCount, actualCount,
                "Add method doesn't add element correctly!");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void Count_ShouldReturnTheNumberOfElements(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int expectedCount = 3;
            int actualCount = this.linkedList.Count;

            Assert.AreEqual(expectedCount, actualCount,
                "Count returns wrong value!");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void GetElement_FromValidIndex_ShouldReturnTheCorrectValue(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int expectedValue = 3;
            int actualValue = this.linkedList[this.linkedList.Count - 1];

            Assert.AreEqual(expectedValue, actualValue,
                "Get element doesn't return the correct value!");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void GetElement_FromInvalidIndex_ShouldThrowArgumentOutOfRangeException(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int invalidIndex = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int element = this.linkedList[invalidIndex];

            }, $"Invalid index: {invalidIndex}");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void SetValue_AtValidIndex_ShouldSetItCorrectly(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int expectedValue = 5;
            this.linkedList[this.linkedList.Count - 1] = expectedValue;
            int actualValue = this.linkedList[this.linkedList.Count - 1];

            Assert.AreEqual(expectedValue, actualValue,
                "Set element doesn't set correctly!");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void SetValue_AtInvalidIndex_ShouldThrowArgumentOutOfRangeException(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int invalidIndex = this.linkedList.Count;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.linkedList[invalidIndex] = 4;

            }
            , $"Invalid index: {invalidIndex}");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void RemoveAt_FromValidIndex_ShouldRemoveTheItemCorrectly(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int index = 1;
            var tempList = new List<int> { 1, 3 };
            this.linkedList.RemoveAt(index);

            for (int i = 0; i < this.linkedList.Count; i++)
            {
                Assert.AreEqual(tempList[i], this.linkedList[i]);
            }
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void RemoveAt_FromValidIndex_ShouldReturnTheCorrectIndex(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int index = 1;
            var expectedResult = 2;
            var actualResult = this.linkedList.RemoveAt(index);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void RemoveAt_FromValidIndex_ShouldDecreaseTheCount(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int index = 1;
            this.linkedList.RemoveAt(index);

            var expectedResult = 2;
            var actualResult = this.linkedList.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveAt_FromInvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            int invalidIndex = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() 
                => this.linkedList.RemoveAt(invalidIndex),
                $"Invalid index: {invalidIndex}");
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void Remove_ExistingItem_ShouldReturnTheCorrectIndex(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            var existingItem = 3;
            var expectedResult = 2;
            var actualResult = this.linkedList.Remove(existingItem);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_NonExistingItem_ShouldReturnTheCorrectIndex()
        {
            var nonExistingItem = 3;
            var expectedResult = -1;
            var actualResult = this.linkedList.Remove(nonExistingItem);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void Remove_ExistingItem_ShouldDecreaseTheCount(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            var existingItem = 3;
            this.linkedList.Remove(existingItem);

            var expectedResult = 2;
            var actualResult = this.linkedList.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void IndexOf_ExistingItem_ShouldReturnTheCorrectIndex(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            var existingItem = 3;
            var expectedResult = 2;
            var actualResult = this.linkedList.IndexOf(existingItem);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void IndexOf_NonExistingItem_ShouldReturnTheCorrectIndex()
        {
            var nonExistingItem = 3;
            var expectedResult = -1;
            var actualResult = this.linkedList.IndexOf(nonExistingItem);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        public void Contains_ExistingItem_ShouldReturnTrue(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            var existingItem = 3;
            var expectedResult = true;
            var actualResult = this.linkedList.Contains(existingItem);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Contains_NonExistingItem_ShouldReturnFalse()
        {
            var nonExistingItem = 3;
            var expectedResult = false;
            var actualResult = this.linkedList.Contains(nonExistingItem);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
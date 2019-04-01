namespace P03_CustomLinkedList.Tests
{
    using System;
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
        public void AddMethodShouldAddElement(int[] elements)
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
        public void CountPropertyShouldReturnTheNumberOfElements(int[] elements)
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
        public void GetElementFromValidIndexShouldReturnTheCorrectValue(int[] elements)
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
        public void GetElementFromInvalidIndexShouldThrowException(int[] elements)
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
        public void SetValueAtValidIndexShouldSetItCorrectly(int[] elements)
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
        public void SetValueAtInvalidIndexShouldThrowException(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.linkedList.Add(elements[i]);
            }

            int invalidIndex = this.linkedList.Count;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int element = this.linkedList[invalidIndex];

            }, $"Invalid index: {invalidIndex}");
        }
    }
}
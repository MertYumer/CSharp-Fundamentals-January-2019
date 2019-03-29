namespace P01_Database.Tests
{
    using System.Linq;
    using NUnit.Framework;
    using P01_Database;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] array;
        private int[] largerArray;
        private int[] fullArray;

        [SetUp]
        public void SetUp()
        {
            this.array = Enumerable.Range(1, 8).ToArray();
            this.largerArray = Enumerable.Range(1, 17).ToArray();
            this.fullArray = Enumerable.Range(1, 16).ToArray();
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            var database = new Database(array);

            int[] actualData = database.Fetch();

            Assert.That(actualData, Is.EqualTo(array));
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWithLargerArray()
        {
            Assert.That(() => new Database(largerArray),
                Throws.InvalidOperationException);
        }

        [Test]
        public void AddShouldAddElement()
        {
            var data = new Database(this.array);
            data.Add(9);

            int[] expectedResult = this.array.Concat(new int[] { 9 }).ToArray();
            int[] actualResult = data.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddToFullDataShouldThrowInvalidOperationException()
        {
            var data = new Database(this.fullArray);

            Assert.That(() => data.Add(17),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemoveTheLastElement()
        {
            var data = new Database(this.array);
            data.Remove();

            int expectedResult = this.array.Skip(this.array.Length - 2).Take(1).Last();
            int actualResult = data.Fetch().Last();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveFromEmptyDataShouldThrowInvalidOperationException()
        {
            var data = new Database();

            Assert.That(() => data.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void FetchShouldReturnArrayCorrectly()
        {
            var data = new Database(this.array);

            int[] expectedResult = this.array;
            int[] actualResult = data.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
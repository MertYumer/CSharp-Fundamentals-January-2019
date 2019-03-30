namespace P02_ExtendedDatabase.Tests
{
    using NUnit.Framework;
    using P02_ExtendedDatabase;

    [TestFixture]
    public class PersonDatabaseTests
    {
        private Person firstPerson;
        private Person secondPerson;

        [SetUp]
        public void SetUp()
        {
            this.firstPerson = new Person("Michael", 101);
            this.secondPerson = new Person("John", 102);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            var expectedResult = new Person[] { firstPerson, secondPerson };

            var database = new Database(expectedResult);

            var actualResult = database.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddShouldNotAddExistingUsername()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);
            var person = new Person("Michael", 153);

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException, "Person with the" +
                    " same username already exists!");
        }

        [Test]
        public void AddShouldNotAddExistingId()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);
            var person = new Person("Nick", 101);

            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException, "Person with the" +
                    " same id already exists!");
        }

        [Test]
        public void RemoveShouldRemoveTheLastPerson()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);
            database.Remove();

            var expectedResult = new Person[] { firstPerson };
            var actualResult = database.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveFromEmptyDataShouldThrowInvalidOperationException()
        {
            var database = new Database();

            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException, "Data is empty!");
        }

        [Test]
        public void FindByUsernameNonExistingPersonShouldThrowInvalidOperationException()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);

            Assert.That(() => database.FindByUsername("Ron"),
                Throws.InvalidOperationException, "Person with this " +
                    "username doesn't exist!");
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrowInvalidOperationException()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);

            Assert.That(() => database.FindByUsername(null), 
                Throws.ArgumentNullException, "Username cannot be null or empty!");
        }

        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);

            Assert.That(() => database.FindByUsername("michael"),
                Throws.InvalidOperationException, "Person with this " +
                    "username doesn't exist!");
        }

        [Test]
        public void FindByIdNonExistingPersonShouldThrowInvalidOperationException()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);

            Assert.That(() => database.FindById(123),
                Throws.InvalidOperationException, "Person with this " +
                    "id doesn't exist!");
        }

        [Test]
        public void FindByIdNegativeArgumentShouldThrowArgumentOutOfRangeException()
        {
            var people = new Person[] { firstPerson, secondPerson };
            var database = new Database(people);

            Assert.That(() => database.FindById(-1),
                Throws.ArgumentException, "Id cannot be less than zero!");
        }
    }
}

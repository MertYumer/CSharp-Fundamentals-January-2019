    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int Health = 10;
        private const int Experience = 10;

        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(Health, Experience);
        }

        [TestCase(5)]
        public void DummyLoosesHealthIfAttacked(int attackPoints)
        {
            dummy.TakeAttack(attackPoints);

            int expectedResult = 5;
            int actualResult = dummy.Health;

            Assert.AreEqual(expectedResult, actualResult,
                "Dummy doesn't loose health when is attacked.");
        }

        [TestCase(0, 5)]
        public void DeadDummyThrowsExceptionIfAttacked(int health, int attackPoints)
        {
            this.dummy = new Dummy(health, Experience);
            
            Assert.That(() => dummy.TakeAttack(5), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        [TestCase(0)]
        public void DeadDummyCanGiveXP(int health)
        {
            this.dummy = new Dummy(health, Experience);
            int expectedResult = 10;
            int actualResult = dummy.GiveExperience();

            Assert.AreEqual(expectedResult, actualResult,
                "Dead dummy doesn't give experience.");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }
    }

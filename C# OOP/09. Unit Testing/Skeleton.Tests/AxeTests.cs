    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private const int AttackPoints = 10;
        private const int DurabilityPoints = 10;
        private const int Health = 10;
        private const int Experience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(AttackPoints, DurabilityPoints);
            this.dummy = new Dummy(Health, Experience);
        }

        [Test]
        public void TestIfWeaponLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9),
                 "Axe Durability doesn't change after attack");
        }

        [TestCase(0)]
        public void TestAttackingWithBrokenWeapon(int durability)
        {
            this.axe = new Axe(AttackPoints, durability);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }

namespace P04_StorageMaster.Tests.Structure
{
    using System.Linq;
    using NUnit.Framework;
    using Entities.Vehicles;
    using Entities.Products;
    using System.Reflection;

    [TestFixture]
    public class ProductTests
    {
        private PropertyInfo[] properties;
        private MethodInfo[] methods;

        [SetUp]
        public void SetUp()
        {
            this.properties = typeof(Product)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            this.methods = typeof(Product)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }

        [Test]
        public void ProductClass_ShouldBeAbstract()
        {
            Assert.IsTrue(typeof(Vehicle).IsAbstract);
        }

        [Test]
        public void Product_ShouldHavePrivateFieldOfTypeDouble()
        {
            var fields = typeof(Product)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.First();

            Assert.AreEqual(field.FieldType, typeof(double));
        }

        [Test]
        public void Product_ShouldHavePriceProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Price"));
        }

        [Test]
        public void Product_PriceProperty_ShouldReturnDouble()
        {
            var price = properties.First(p => p.Name == "Price");

            Assert.IsTrue(price.PropertyType == typeof(double));
        }

        [Test]
        public void Product_ShouldHaveWeightProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Weight"));
        }

        [Test]
        public void Product_WeightProperty_ShouldReturnIReadOnlyCollectionOfProducts()
        {
            var weight = properties.First(p => p.Name == "Weight");

            Assert.IsTrue(weight.PropertyType == typeof(double));
        }
    }
}

namespace P04_StorageMaster.Tests.Structure
{
    using System.Linq;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Entities.Vehicles;
    using Entities.Products;
    using System.Reflection;
    using System;

    [TestFixture]
    public class VehicleTests
    {
        private PropertyInfo[] properties;
        private MethodInfo[] methods;

        [SetUp]
        public void SetUp()
        {
            this.properties = typeof(Vehicle)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            this.methods = typeof(Vehicle)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }

        [Test]
        public void VehicleClass_ShouldBeAbstract()
        {
            Assert.IsTrue(typeof(Vehicle).IsAbstract);
        }

        [Test]
        public void Vehicle_ShouldHavePrivateListOfProducts()
        {
            var fields = typeof(Vehicle)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.First();

            Assert.AreEqual(field.FieldType, typeof(List<Product>));
        }

        [Test]
        public void Vehicle_ShouldHaveConstructor()
        {
            var constructors = typeof(Vehicle)
                .GetConstructors(BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Public);

            Type[] parameterTypes = new Type[] { typeof(int) };

            var constructor = typeof(Vehicle)
                .GetConstructor(BindingFlags.NonPublic
                | BindingFlags.Public | BindingFlags.Instance,
                null, parameterTypes, null);

            Assert.IsTrue(constructor != null);
        }

        [Test]
        public void Vehicle_ShouldHaveCapacityProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Capacity"));
        }

        [Test]
        public void Vehicle_CapacityProperty_ShouldReturnInt()
        {
            var capacity = properties.First(p => p.Name == "Capacity");

            Assert.IsTrue(capacity.PropertyType == typeof(int));
        }

        [Test]
        public void Vehicle_ShouldHaveTrunkProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Trunk"));
        }

        [Test]
        public void Vehicle_TrunkProperty_ShouldReturnIReadOnlyCollectionOfProducts()
        {
            var trunk = properties.First(p => p.Name == "Trunk");

            Assert.IsTrue(trunk.PropertyType == typeof(IReadOnlyCollection<Product>));
        }

        [Test]
        public void Vehicle_ShouldHaveIsFullProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "IsFull"));
        }

        [Test]
        public void Vehicle_IsFullProperty_ShouldReturnBool()
        {
            var isFullProperty = properties.First(p => p.Name == "IsFull");

            Assert.IsTrue(isFullProperty.PropertyType == typeof(bool));
        }

        [Test]
        public void Vehicle_ShouldHaveIsEmptyProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "IsEmpty"));
        }

        [Test]
        public void Vehicle_IsEmptyProperty_ShouldReturnBool()
        {
            var isEmptyProperty = properties.First(p => p.Name == "IsEmpty");

            Assert.IsTrue(isEmptyProperty.PropertyType == typeof(bool));
        }

        [Test]
        public void Vehicle_ShouldHaveLoadProductMethod()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "LoadProduct"));
        }

        [Test]
        public void Vehicle_LoadProductMethod_ShouldReturnVoid()
        {
            var loadProductMethod = methods.First(m => m.Name == "LoadProduct");

            Assert.IsTrue(loadProductMethod.ReturnType == typeof(void));
        }

        [Test]
        public void Vehicle_ShouldHaveUnloadMethod()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "Unload"));
        }

        [Test]
        public void Vehicle_UnloadMethod_ShouldReturnProduct()
        {
            var unloadMethod = methods.First(m => m.Name == "Unload");

            Assert.IsTrue(unloadMethod.ReturnType == typeof(Product));
        }
    }
}
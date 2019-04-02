namespace P04_StorageMaster.Tests.Structure
{
    using System.Linq;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Entities.Vehicles;
    using Entities.Products;
    using System.Reflection;
    using Entities.Storage;
    using System;

    [TestFixture]
    public class StorageTests
    {
        private PropertyInfo[] properties;
        private MethodInfo[] methods;

        [SetUp]
        public void SetUp()
        {
            this.properties = typeof(Storage)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            this.methods = typeof(Storage)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }

        [Test]
        public void ProductClass_ShouldBeAbstract()
        {
            Assert.IsTrue(typeof(Storage).IsAbstract);
        }

        [Test]
        public void Storage_ShouldHavePrivateArrayOfVehicles()
        {
            var fields = typeof(Storage)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.First();

            Assert.AreEqual(field.FieldType, typeof(Vehicle[]));
        }

        [Test]
        public void Storage_ShouldHavePrivateListOfProducts()
        {
            var fields = typeof(Storage)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.Skip(1).First();

            Assert.AreEqual(field.FieldType, typeof(List<Product>));
        }

        [Test]
        public void Storage_ShouldHaveConstructor()
        {
            var constructors = typeof(Storage)
                .GetConstructors(BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Public);

            Type[] parameterTypes = new Type[] { typeof(string), typeof(int),
                    typeof(int), typeof(IEnumerable<Vehicle>)};

            var constructor = typeof(Storage)
                .GetConstructor(BindingFlags.NonPublic 
                | BindingFlags.Public | BindingFlags.Instance,
                null, parameterTypes, null);

            Assert.IsTrue(constructor != null);
        }
    }
}

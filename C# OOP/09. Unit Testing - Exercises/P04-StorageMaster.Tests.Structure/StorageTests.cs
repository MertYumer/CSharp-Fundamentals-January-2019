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

        [Test]
        public void Storage_ShouldHaveNameProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Name"));
        }

        [Test]
        public void Storage_NameProperty_ShouldReturnString()
        {
            var nameProperty = properties.First(p => p.Name == "Name");

            Assert.IsTrue(nameProperty.PropertyType == typeof(string));
        }

        [Test]
        public void Storage_ShouldHaveCapacityProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Capacity"));
        }

        [Test]
        public void Storage_CapacityProperty_ShouldReturnInt()
        {
            var capacityProperty = properties.First(p => p.Name == "Capacity");

            Assert.IsTrue(capacityProperty.PropertyType == typeof(int));
        }

        [Test]
        public void Storage_ShouldHaveGarageSlotsProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "GarageSlots"));
        }

        [Test]
        public void Storage_GarageSlotsProperty_ShouldReturnInt()
        {
            var garageSlotsProperty = properties.First(p => p.Name == "GarageSlots");

            Assert.IsTrue(garageSlotsProperty.PropertyType == typeof(int));
        }

        [Test]
        public void Storage_ShouldHaveIsFullProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "IsFull"));
        }

        [Test]
        public void Storage_IsFullProperty_ShouldReturnBool()
        {
            var isFullProperty = properties.First(p => p.Name == "IsFull");

            Assert.IsTrue(isFullProperty.PropertyType == typeof(bool));
        }

        [Test]
        public void Storage_ShouldHaveGarageProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Garage"));
        }

        [Test]
        public void Storage_GarageProperty_ShouldReturnIReadOnlyCollectionOfVehicles()
        {
            var garageProperty = properties.First(p => p.Name == "Garage");

            Assert.IsTrue(garageProperty.PropertyType == typeof(IReadOnlyCollection<Vehicle>));
        }

        [Test]
        public void Storage_ShouldHaveProductsProperty()
        {
            Assert.IsTrue(properties.Any(p => p.Name == "Products"));
        }

        [Test]
        public void Storage_ProductsProperty_ShouldReturnIReadOnlyCollectionOfProducts()
        {
            var productProperty = properties.First(p => p.Name == "Products");

            Assert.IsTrue(productProperty.PropertyType == typeof(IReadOnlyCollection<Product>));
        }

        [Test]
        public void Storage_ShouldHaveGetVehicleMethod()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "GetVehicle"));
        }

        [Test]
        public void Storage_GetVehicleMethod_ShouldReturnVehicle()
        {
            var getVehicleMethod = methods.First(m => m.Name == "GetVehicle");

            Assert.IsTrue(getVehicleMethod.ReturnType == typeof(Vehicle));
        }

        [Test]
        public void Storage_ShouldHaveSendVehicleToMethod()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "SendVehicleTo"));
        }

        [Test]
        public void Storage_SendVehicleToMethod_ShouldReturnInt()
        {
            var sendVehicleToMethod = methods.First(m => m.Name == "SendVehicleTo");

            Assert.IsTrue(sendVehicleToMethod.ReturnType == typeof(int));
        }

        [Test]
        public void Storage_ShouldHaveUnloadVehicleMethod()
        {
            Assert.IsTrue(methods.Any(m => m.Name == "UnloadVehicle"));
        }

        [Test]
        public void Storage_UnloadVehicleMethod_ShouldReturnInt()
        {
            var unloadVehicleMethod = methods.First(m => m.Name == "UnloadVehicle");

            Assert.IsTrue(unloadVehicleMethod.ReturnType == typeof(int));
        }
    }
}

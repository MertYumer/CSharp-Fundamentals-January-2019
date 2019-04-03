namespace P04_StorageMaster.Tests.BusinessLogic
{
    using NUnit.Framework;
    using Core;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Entities.Products;
    using Entities.Storage;
    using Entities.Vehicles;

    [TestFixture]
    public class StorageMasterTests
    {
        private StorageMaster storageMaster;

        [SetUp]
        public void Setup()
        {
            storageMaster = (StorageMaster)Activator.CreateInstance(typeof(StorageMaster));
        }

        [Test]
        public void StorageMaster_Constructor_ShouldCreateInstances()
        {
            Assert.IsTrue(storageMaster.GetType() == typeof(StorageMaster));
        }

        [Test]
        public void StorageMaster_AddProductMethod_ShouldWorkCorrectly()
        {
            var productsPool = typeof(StorageMaster)
                .GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance);

            var productsPoolValue = (Dictionary<string,
                Stack<Product>>)productsPool.GetValue(storageMaster);

            var addProductMethod = typeof(StorageMaster).GetMethod("AddProduct");
            string productType = "Ram";
            double price = 10.5;

            var actualResult = addProductMethod
                .Invoke(storageMaster, new object[] { productType, price });
            
            Assert.IsTrue(productsPoolValue.ContainsKey(productType));
        }

        [Test]
        public void StorageMaster_AddProductMethod_ShouldReturnTheCorrectString()
        {
            var productsPool = typeof(StorageMaster)
                .GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance);

            var productsPoolValue = (Dictionary<string,
                Stack<Product>>)productsPool.GetValue(storageMaster);

            var addProductMethod = typeof(StorageMaster).GetMethod("AddProduct");
            string productType = "Ram";
            double price = 10.5;

            string expectedResult = $"Added {productType} to pool";
            var actualResult = addProductMethod
                .Invoke(storageMaster, new object[] { productType, price });

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void StorageMaster_RegisterStorageMethod_ShouldWorkCorrectly()
        {
            var storageRegistry = typeof(StorageMaster)
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);

            var storageRegistryValue = (Dictionary<string, Storage>)storageRegistry
                .GetValue(storageMaster);

            var registerStorageMethod = typeof(StorageMaster).GetMethod("RegisterStorage");
            string storageType = "Warehouse";
            string storageName = "ABC";

            var actualResult = registerStorageMethod
                .Invoke(storageMaster, new object[] { storageType, storageName });

            Assert.IsTrue(storageRegistryValue.ContainsKey(storageName));
        }

        [Test]
        public void StorageMaster_RegisterStorageMethod_ShouldReturnTheCorrectString()
        {
            var storageRegistry = typeof(StorageMaster)
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);

            var storageRegistryValue = (Dictionary<string, Storage>)storageRegistry
                .GetValue(storageMaster);

            var registerStorageMethod = typeof(StorageMaster).GetMethod("RegisterStorage");
            string storageType = "Warehouse";
            string storageName = "ABC";

            string expectedResult = $"Registered {storageName}";
            var actualResult = registerStorageMethod
                .Invoke(storageMaster, new object[] { storageType, storageName });

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void StorageMaster_SelectVehicleMethod_ShouldWorkCorrectly()
        {
            var storageRegistry = typeof(StorageMaster)
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);

            var storageRegistryValue = (Dictionary<string, Storage>)storageRegistry
                .GetValue(storageMaster);

            var registerStorageMethod = typeof(StorageMaster).GetMethod("RegisterStorage");
            string storageType = "Warehouse";
            string storageName = "ABC";

            registerStorageMethod
                .Invoke(storageMaster, new object[] { storageType, storageName });

            int garageSlot = 1;
            var storage = storageRegistryValue[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            var currentVehicle = typeof(StorageMaster)
                .GetField("currentVehicle", BindingFlags.NonPublic | BindingFlags.Instance);

            currentVehicle.SetValue(storageMaster, vehicle);

            var selectVehicleMethod = typeof(StorageMaster).GetMethod("SelectVehicle");

            var expectedResult = vehicle;
            var actualResult = (Vehicle)currentVehicle
                .GetValue(storageMaster);

            Assert.AreSame(expectedResult, actualResult);
        }

        [Test]
        public void StorageMaster_SelectVehicleMethod_ShouldReturnTheCorrectString()
        {
            var storageRegistry = typeof(StorageMaster)
                .GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);

            var storageRegistryValue = (Dictionary<string, Storage>)storageRegistry
                .GetValue(storageMaster);

            var registerStorageMethod = typeof(StorageMaster).GetMethod("RegisterStorage");
            string storageType = "Warehouse";
            string storageName = "ABC";

            registerStorageMethod
                .Invoke(storageMaster, new object[] { storageType, storageName });

            int garageSlot = 1;
            var storage = storageRegistryValue[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            var currentVehicle = typeof(StorageMaster)
                .GetField("currentVehicle", BindingFlags.NonPublic | BindingFlags.Instance);

            currentVehicle.SetValue(storageMaster, vehicle);

            var selectVehicleMethod = typeof(StorageMaster).GetMethod("SelectVehicle");

            var expectedResult = $"Selected {vehicle.GetType().Name}";
            var actualResult = selectVehicleMethod
                .Invoke(storageMaster, new object[] { storageName, garageSlot });

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
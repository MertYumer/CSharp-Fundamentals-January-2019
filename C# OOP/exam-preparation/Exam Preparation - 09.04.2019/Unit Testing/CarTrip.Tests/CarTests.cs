using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase("ABC", 20.5, 10.3, 5.5)]
        public void Constructor_ShouldSetValidValuesCorrectly(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);

            var expectedModel = model;
            var actualModel = car.Model;

            var expectedTankCapacity = tankCapacity;
            var actualTankCapacity = car.TankCapacity;

            var expectedTank = tank;
            var actualTank = car.FuelAmount;

            var expectedFuelConsumption = fuelConsumptionPerKm;
            var actualFuelConsumption = car.FuelConsumptionPerKm;

            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedTankCapacity, actualTankCapacity);
            Assert.AreEqual(expectedTank, actualTank);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [TestCase("", 20.5, 10.3, 5.5)]
        [TestCase(null, 20.5, 10.3, 5.5)]
        [TestCase("ABC", 20.5, 10.3, -5.5)]
        public void Constructor_ShouldThrowArgumentExceptionForInvalidParameter(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(model, tankCapacity, tank, fuelConsumptionPerKm));
        }

        [TestCase("ABC", 30.5, 10.3, 5.5)]
        public void FuelAmountProperty_ShouldSetCorrectlyForValidValue(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);
            car.FuelAmount = 25;

            var expected = 25;
            var actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("ABC", 20.5, 10.3, 5.5)]
        public void FuelAmountProperty_ShouldThrowArgumentExceptionForInvalidValue(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);

            Assert.Throws<ArgumentException>(() => car.FuelAmount = 25.30);
        }

        [TestCase("ABC", 150, 100, 5.5, 10)]
        public void DriveMethod_ShouldDecreaseFuelAmountForValidParameter(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm, double distance)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);
            car.Drive(distance);

            var expected = 45;
            var actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("ABC", 100, 30, 5.5, 10)]
        public void DriveMethod_ShouldThrowInvalidOperationExceptionForInvalidParameter(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm, double distance)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [TestCase("ABC", 150, 100, 5.5, 10)]
        public void RefuelMethod_ShouldIncreaseFuelAmountForValidParameter(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm, double fuelAmount)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);
            car.Refuel(fuelAmount);

            var expected = 110;
            var actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("ABC", 35, 30, 5.5, 10)]
        public void RefuelMethod_ShouldThrowInvalidOperationExceptionForInvalidDistance(string model,
            double tankCapacity, double tank, double fuelConsumptionPerKm, double fuelAmount)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);

            Assert.Throws<InvalidOperationException>(() => car.Refuel(fuelAmount));
        }
    }
}
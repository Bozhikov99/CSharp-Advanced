//using CarManager;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Threading;

namespace Tests
{
    public class CarTests
    {
        private Car testCar;

        [SetUp]
        public void Setup()
        {
            testCar = new Car("Make", "Model", 5.1, 40);
        }

        [Test]
        [TestCase("", "Model", 5.1, 40)]            //Make
        [TestCase(null, "Model", 5.1, 40)]
        [TestCase("Make", "", 5.1, 40)]             //Model
        [TestCase("Make", null, 5.1, 40)]
        [TestCase("Make", "Model", 0, 40)]           //FuelConsumption
        [TestCase("Make", "Model", -1, 40)]
        [TestCase("Make", "Model", 5.1, 0)]          //FuelCapacity
        [TestCase("Make", "Model", 5.1, -1)]
        public void Constructor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => testCar.Refuel(fuelAmount));
        }

        [Test]
        public void Refuel_IncreasesFuelAmountCorrectly()
        {
            testCar.Refuel(testCar.FuelCapacity/2);

            Assert.AreEqual(testCar.FuelAmount, testCar.FuelCapacity/2);
        }

        [Test]
        public void Refuel_FuelIsEqualToCapacity_WhenExceeded()
        {
            testCar.Refuel(testCar.FuelCapacity * 1.2);
            Assert.AreEqual(testCar.FuelCapacity, testCar.FuelAmount);
        }

        [Test]
        public void Drive_ThrowsInvalidOperationException_WhenHasNoFuel()
        {
            Assert.Throws<InvalidOperationException>(() => testCar.Drive(1));
        }

        [Test]
        public void Drive_DecreasesFuel()
        {
            testCar.Refuel(testCar.FuelCapacity);

            testCar.Drive(testCar.FuelCapacity / 2);

            Assert.AreEqual(testCar.FuelAmount, testCar.FuelCapacity - (testCar.FuelCapacity / 2) / 100 * testCar.FuelConsumption);
        }
    }
}
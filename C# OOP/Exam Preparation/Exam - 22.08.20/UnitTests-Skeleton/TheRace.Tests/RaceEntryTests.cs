using NUnit.Framework;
using System;
using System.Numerics;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry testEntry;
        [SetUp]
        public void Setup()
        {
            testEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => testEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsAddedTwice()
        {
            string name = "Stancho";
            UnitDriver driver = CreateSimpleDriver(name);
            testEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => testEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_IncreasesCount_WhenAddingValidDriver()
        {
            string name = "Stancho";
            UnitDriver driver = CreateSimpleDriver(name);
            testEntry.AddDriver(driver);

            int predicted = 1;

            Assert.AreEqual(predicted, testEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenParticipantsAreNotEnough()
        {
            string name = "Stancho";
            testEntry.AddDriver(CreateSimpleDriver(name));

            Assert.Throws<InvalidOperationException>(() => testEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsCorrectly()
        {
            string firstName = "Peycho";
            string secondName = "Stancho";
            string thirdName = "Trohan";

            testEntry.AddDriver(CreateSimpleDriver(firstName));
            testEntry.AddDriver(CreateSimpleDriver(secondName));
            testEntry.AddDriver(CreateSimpleDriver(thirdName));

            double predicted = 130;

            Assert.AreEqual(predicted, testEntry.CalculateAverageHorsePower());
        }

        private UnitDriver CreateSimpleDriver(string name)
        {
            string model = "Bora";
            int horsePower = 130;
            double cubicCm = 1900;

            UnitCar car = new UnitCar(model, horsePower, cubicCm);
            UnitDriver driver = new UnitDriver(name, car);
            return driver;
        }
    }
}
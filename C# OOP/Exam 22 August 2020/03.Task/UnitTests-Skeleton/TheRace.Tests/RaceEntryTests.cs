using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Audi", 300, 3200);
            driver = new UnitDriver("John", car);
            race = new RaceEntry();
        }

        [Test]
        public void Ctor_InitializedUnitCarWithCorrectValue()
        {
            string expectedModel = "Audi";
            int expectedHP = 300;
            double expectedCC = 3200;

            Assert.That(car.Model, Is.EqualTo(expectedModel));
            Assert.That(car.HorsePower, Is.EqualTo(expectedHP));
            Assert.That(car.CubicCentimeters, Is.EqualTo(expectedCC));
        }

        [Test]
        public void Ctor_InitializedUnitDriverWithCorrectValue()
        {
            string expectedName = "John";
            UnitCar expetedCar = car;

            Assert.That(driver.Name, Is.EqualTo(expectedName));
            Assert.That(driver.Car, Is.EqualTo(expetedCar));
        }

        [Test]
        public void Ctor_InitializedUnitDriverWithNullNameShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => driver = new UnitDriver(null, car));
        }

        [Test]
        public void Ctor_InitializedRaceEntryWithCorrectValue()
        {
            int expectedCount = 0;

            Assert.That(race.Counter, Is.EqualTo(expectedCount));
        }

        [Test]
        public  void AddDriver_NullShouldThrowException()
        {
            driver = null;

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ExistingDriverShouldThrowException()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ShouldAddDriverAndReturnMessage()
        {
            int expectedCount = 1;
            string expectedMessage = "Driver John added in race.";

            Assert.That(race.AddDriver(driver), Is.EqualTo(expectedMessage));
            Assert.That(race.Counter, Is.EqualTo(expectedCount));
        }

        [Test]
        public void CalculateAverageHorsePower_IfDriverCountIsLessThanMinShouldThrowExceprtion()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldReturnAverageHp()
        {
            var driverTwo = new UnitDriver("Peter", new UnitCar("BMW", 100, 1600));
            var driverThree = new UnitDriver("Dom", new UnitCar("Pontiac", 200, 5000));
            
            race.AddDriver(driver);
            race.AddDriver(driverTwo);
            race.AddDriver(driverThree);

            int expectedHp = 200;

            Assert.That(race.CalculateAverageHorsePower(), Is.EqualTo(expectedHp));
        }
    }
}
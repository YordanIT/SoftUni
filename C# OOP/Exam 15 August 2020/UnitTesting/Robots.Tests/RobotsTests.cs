namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("TX", 100);
            manager = new RobotManager(1);
        }

        [Test]
        public void Ctor_InitializedRobotWithCorrectValue()
        {
            Assert.That(robot.Name, Is.EqualTo("TX"));
            Assert.That(robot.Battery, Is.EqualTo(100));
            Assert.That(robot.MaximumBattery, Is.EqualTo(100));
        }

        [Test]
        public void Ctor_InitializedRobotManagerWithCorrectValue()
        {
            Assert.That(manager.Capacity, Is.EqualTo(1));
            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_InitializedRobotManagerWithNegativeCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => manager = new RobotManager(-10));
        }

        [Test]
        public void Add_ShouldThrowExceptionWhenRobotExist()
        {
            manager.Add(robot);
            string message = "There is already a robot with name TX!";

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot), message);
        }

        [Test]
        public void Add_ShouldThrowExceptionWhenNotEnoughCapacity()
        {
            manager.Add(robot);
            string message = "Not enough capacity!";

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot), message);
        }

        [Test]
        public void Add_ShouldAddRobot()
        {
            manager.Add(robot);

            Assert.That(manager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ShouldThrowExceptionWhenRobotNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Remove("T1000"));
        }

        [Test]
        public void Remove_ShouldRemoveRobot()
        {
            manager.Add(robot);
            manager.Remove("TX");

            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Work_ShouldThrowExceptionWhenRobotNotExist()
        {
            string message = "Robot with the name TX doesn't exist!";

            Assert.Throws<InvalidOperationException>(() => manager.Work("T500", "drive", 100), message);
        }

        [Test]
        public void Work_ShouldThrowExceptionWhenRobotDoesntHaveEnoughBattery()
        {
            manager.Add(robot);
            string message = "TX doesn't have enough battery!"; 
            Assert.Throws<InvalidOperationException>(() => manager.Work("TX", "drive", 200), message);
        }

        [Test]
        public void Work_ShouldDecreaseBatteryByBatteryUsage()
        {
            manager.Add(robot);
            manager.Work("TX", "drive", 50);

           Assert.That(robot.Battery, Is.EqualTo(50));
        }

        [Test]
        public void Charge_ShouldThrowExceptionWhenRobotNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("T200"));
        }

        [Test]
        public void Charge_ShouldIncreaseBatteryToMax()
        {
            manager.Add(robot);
            manager.Work("TX", "drive", 50);
            manager.Charge("TX");

            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }
    }
}

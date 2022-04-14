namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            present = new Present("Toy", 10.5);
            bag = new Bag();
        }

        [Test]
        public void Ctor_InitializedPresentWithCorrectValue()
        {
            Assert.That(present.Name, Is.EqualTo("Toy"));
            Assert.That(present.Magic, Is.EqualTo(10.5));
        }

        [Test]
        public void Ctor_InitializedBagWithCorrectValue()
        {
            int expectedCount = 0;
            var presentsInBag = bag.GetPresents();

            Assert.That(presentsInBag.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Create_ShouldAddPresentAndReturnMessage()
        {
            int expectedCount = 1;
            bag.Create(present);
            var presentsInBag = bag.GetPresents();

            Assert.That(presentsInBag.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Create_ShouldReturnMessageWhenAdd()
        {
            string expectedMessage = "Successfully added present Toy.";
            string message = bag.Create(present);

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Create_ShouldThrowExceptionWhenAddNull()
        {
            present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void Create_ShouldThrowExceptionWhenAddExistingPresent()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Remove_ShouldReturnTrueWhenRemoveSuccessfully()
        {
            bag.Create(present);
            bool removePresent = bag.Remove(present);
            int expectedCount = 0;
            var presentsInBag = bag.GetPresents();

            Assert.IsTrue(removePresent);
            Assert.That(presentsInBag.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ShouldReturnFalseWhenDontRemove()
        {
            bool removePresent = bag.Remove(present);
            int expectedCount = 0;
            var presentsInBag = bag.GetPresents();

            Assert.IsFalse(removePresent);
            Assert.That(presentsInBag.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetPresentWithLeastMagic_ShouldReturnPresent()
        {
            var presentTwo = new Present("small", 1.1);
            bag.Create(presentTwo);
            var leastMagicPresent = bag.GetPresentWithLeastMagic();

            Assert.That(presentTwo, Is.EqualTo(leastMagicPresent));
        }

        [Test]
        public void GetPresent_ShouldReturnPresentByGivenName()
        {
            bag.Create(present);
            string presentName = "Toy";
            var expectedPresent = present;

            Assert.That(bag.GetPresent(presentName), Is.EqualTo(expectedPresent));
        }

        [Test]
        public void GetPresents_ShouldReturnReadOnlyCollection()
        {
            int expectedCount = 0;
            var presentsInBag = bag.GetPresents();

            Assert.That(presentsInBag.Count, Is.EqualTo(expectedCount));
        }
    }
}

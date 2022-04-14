namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("WaterWorld", 2);
            fish = new Fish("Nemo");
            aquarium.Add(fish);
        }

        [Test]
        public void Ctor_InitializedWithCorrectValue()
        {
            int expectedCount = 1;
            string expectedFishName = "Nemo";

            Assert.That(aquarium.Count, Is.EqualTo(expectedCount));
            Assert.That(fish.Name, Is.EqualTo(expectedFishName));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_NameShouldThrowExeptionWhenNullOrEmpthy(string name)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, 10));
        }

        [Test]
        [TestCase(-10)]
        public void Ctor_CapcityShouldThrowExeptionWhenNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Name", capacity));
        }

        [Test]
        public void Add_ShouldAddFishToAquatium()
        {
            int expectedCount = 1;

            Assert.That(aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_ShouldThrowExeptionWhenAquariumIsFull()
        {
            var fishTwo = new Fish("Nemo two");
            aquarium.Add(fishTwo);
            var fishThree = new Fish("Nemo three");
            
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fishThree));
        }

        [Test]
        public void RemoveFish_ShouldRemoveFishFromAquarium()
        {
            aquarium.RemoveFish(fish.Name);
            int expectedCount = 0;

            Assert.That(aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveFish_ShouldThrowExceptionWhenFishNotFound()
        {
            string notExistingFishName = "No fish";

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(notExistingFishName));
        }

        [Test]
        public void SellFish_ShouldReturnFishWhenRequested()
        {
            var requestedFish = aquarium.SellFish(fish.Name);

            Assert.That(requestedFish, Is.EqualTo(fish));
            Assert.IsFalse(requestedFish.Available);
        }

        [Test]
        public void SellFish_ShouldThrowExceptionWhenRequestedFishNotFound()
        {
            string notExistingFishName = "No fish";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(notExistingFishName));
        }

        [Test]
        public void Report_FishNamesInAquarium()
        {
            var fishTwo = new Fish("Dori");
            aquarium.Add(fishTwo);
            string reportMesssage = "Fish available at WaterWorld: Nemo, Dori";

            Assert.That(aquarium.Report, Is.EqualTo(reportMesssage));
        }
    }
}

using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            item = new Item("John", "1111");
            vault = new BankVault();
        }

        [Test]
        public void Ctor_InitializedItemWithCorectValue()
        {
            string expectedOwner = "John";
            string expectedId = "1111";

            Assert.That(item.Owner, Is.EqualTo(expectedOwner));
            Assert.That(item.ItemId, Is.EqualTo(expectedId));
        }

        [Test]
        public void Ctor_IitializedBankVaultWithCorrectvalue()
        {
            int expectedCount = 12;

            Assert.That(vault.VaultCells.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionWhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("D1", item));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionWhenCellIsTaken()
        {
            vault.AddItem("A1", new Item("Peter", "0000"));

            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionWhenItemIsAlreadyInCell()
        {
            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item));
        }

        [Test]
        public void AddItem_ShouldAddItemToCellWithMessage()
        {
            vault.AddItem("A1", item);
            var expectedItem = item;

            Assert.That(vault.VaultCells["A1"], Is.EqualTo(expectedItem));
        }

        [Test]
        public void AddItem_ShoulReturnhMessage()
        {
            string expectedMessage = "Item:1111 saved successfully!";

            Assert.That(vault.AddItem("A1", item), Is.EqualTo(expectedMessage));
        }

        [Test]
        public void RemoveItem_ShouldThrowExceptionWhenCellDoesnNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("D1", item));
        }

        [Test]
        public void RemoveItem_ShouldThrowExceptionWhenItemIsNotInCell()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", item));
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemFromCell()
        {
            vault.AddItem("A1", item);
            vault.RemoveItem("A1", item);

            Assert.IsNull(vault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItem_ShouldReturnMessage()
        {
            vault.AddItem("A1", item);
            string expectedMessage = "Remove item:1111 successfully!";

            Assert.That(vault.RemoveItem("A1", item), Is.EqualTo(expectedMessage));
        }
    }
}
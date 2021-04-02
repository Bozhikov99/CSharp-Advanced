using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault(); 
        }

        [Test]
        public void CellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("Invalid", new Item("Owner", "N/A")));
        }

        [Test]
        public void CellIsTaken()
        {
            vault.AddItem("A1",SimpleItem());
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", SimpleItem()));
        }

        [Test]
        public void ItemIsInCell()
        {
            vault.AddItem("A1", SimpleItem());
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2", SimpleItem()));
        }

        [Test]
        public void AddItem_Adds()
        {
            Item item = new Item("Pesho", "290");

            string predicted = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(predicted, vault.AddItem("A1",item));
        }

        [Test]
        public void CellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("ABCDEFG", SimpleItem()));
        }

        [Test]
        public void ItemDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", SimpleItem()));
        }

        [Test]
        public void RemoveItemRemovesCorrectly()
        {
            Item item = SimpleItem();
            vault.AddItem("A1", item);

            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expected, vault.RemoveItem("A1", item));
        }

        private Item SimpleItem()
        {
            return new Item("Stancho", "12");
        }
    }
}
namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private IList<IProduct> repo;
        private Mock<IProduct> productMock;
        private TrackingSystem system;

        [SetUp]
        public void Initialize()
        {
            repo = new List<IProduct>();

            productMock = new Mock<IProduct>();
            productMock.Setup(p => p.Label).Returns("Beer");

            system = new TrackingSystem(repo);
        }

        [Test]
        public void Add_SuccessfullyAddsProducts()
        {

            system.Add(productMock.Object);

            //Assert
            Assert.That(system[0].Label, Is.EqualTo("Beer"));
        }

        [Test]
        public void Add_IncreasesCount()
        {
            int predicted = 1;
            system.Add(productMock.Object);

            Assert.That(system.Count, Is.EqualTo(predicted));
        }

        [Test]
        public void Contains_ReturnsProductCorrectly()
        {
            repo.Add(productMock.Object);

            Assert.That(system.Contains(productMock.Object), Is.True);
        }

        [Test]
        public void Label_MustBeUnique()
        {
            system.Add(productMock.Object);

            Assert.Throws<ArgumentException>(() => system.Add(productMock.Object));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2)]
        public void Find_ThrowsException_WhenIndexIsOutOfRange(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => system.Find(index));
        }

        [Test]
        public void Find_ReturnsProperProduct_WhenIndexIsValid()
        {
            repo.Add(productMock.Object);
            IProduct testProduct = system.Find(1);

            Assert.AreEqual(system.Find(1), testProduct);
        }

        [Test]
        public void FindByLabel_ThrowsArgumentException_WhenLabelDoesNotExist()
        {
            string label = "Some label";
            Assert.Throws<ArgumentException>(() => system.FindByLabel(label));
        }

        [Test]
        public void FindByLabel_ReturnsProductCorrectly()
        {
            string label = productMock.Object.Label;

            repo.Add(productMock.Object);
            IProduct systemProduct = system.FindByLabel(label);

            Assert.AreEqual(system.FindByLabel(label), systemProduct);
        }

        [Test]
        public void FindTheMostExpensiveProducts_ThrowsException_WhenSystemIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => system.FindMostExpensiveProducts());
        }

        [Test]
        public void FindTheMostExpensiveProducts_ReturnsCorrectly()
        {
            Mock<IProduct> addProduct1 = new Mock<IProduct>();
            addProduct1.Setup(p => p.Price).Returns(10.59m);

            Mock<IProduct> addProduct2 = new Mock<IProduct>();
            addProduct2.Setup(p => p.Price).Returns(3.99m);

            repo.Add(addProduct1.Object);
            repo.Add(addProduct2.Object);

            Assert.AreEqual(addProduct1.Object, system.FindMostExpensiveProducts());
        }

        [Test]
        public void FindAllByPriceRange_ReturnsEmpty_WhenNoMatches()
        {
            decimal min = 1.99m;
            decimal max = 2.45m;

            IEnumerable<IProduct> matches = system.FindAllByPriceRange(min, max);

            Assert.That(matches, Is.Empty);
        }

        [Test]
        public void FindAllByPriceRange_ReturnsCorrectly()
        {
            Mock<IProduct> addProduct1 = new Mock<IProduct>();
            addProduct1.Setup(p => p.Price).Returns(10.59m);

            Mock<IProduct> addProduct2 = new Mock<IProduct>();
            addProduct2.Setup(p => p.Price).Returns(1.99m);

            Mock<IProduct> addProduct3 = new Mock<IProduct>();
            addProduct3.Setup(p => p.Price).Returns(2.30m);

            Mock<IProduct> addProduct4 = new Mock<IProduct>();
            addProduct4.Setup(p => p.Price).Returns(2.45m);

            Mock<IProduct> addProduct5 = new Mock<IProduct>();
            addProduct5.Setup(p => p.Price).Returns(1.30m);

            repo.Add(addProduct1.Object);
            repo.Add(addProduct2.Object);
            repo.Add(addProduct3.Object);
            repo.Add(addProduct4.Object);
            repo.Add(addProduct5.Object);

            decimal min = 1.99m;
            decimal max = 2.45m;

            List<IProduct> matches = system.FindAllByPriceRange(min, max);

            int predictedCount = 3;

            Assert.AreEqual(predictedCount, matches.Count());
            Assert.That(matches[0].Price > matches[1].Price);
        }

        [Test]
        public void FindAllByPrice_ReturnsEmptyCollection_WhenSystemIsEmpty()
        {
            decimal price = 0.10m;
            List<IProduct> items = system.FindAllByPrice(price);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void FindAllByPrice_ReturnsCollectionCorrectly()
        {
            Mock<IProduct> addProduct1 = new Mock<IProduct>();
            Mock<IProduct> addProduct2 = new Mock<IProduct>();

            addProduct1.Setup(p => p.Price).Returns(1.00m);
            addProduct2.Setup(p => p.Price).Returns(1.00m);

            repo.Add(addProduct1.Object);
            repo.Add(addProduct2.Object);

            int predicted = 2;

            Assert.AreEqual(predicted, system.FindAllByPrice(1.00m).Count);
        }

        [Test]
        public void FindAllByQuantity_ReturnsEmptyCollection_WhenSystemIsEmpty()
        {
            int quantity = 1;
            List<IProduct> items = system.FindAllByQuantity(quantity);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void FindAllByQuantity_ReturnsCollectionCorrectly()
        {
            Mock<IProduct> addProduct1 = new Mock<IProduct>();
            Mock<IProduct> addProduct2 = new Mock<IProduct>();

            addProduct1.Setup(p => p.Quantity).Returns(1);
            addProduct2.Setup(p => p.Quantity).Returns(1);

            repo.Add(addProduct1.Object);
            repo.Add(addProduct2.Object);

            int predicted = 2;

            Assert.AreEqual(predicted, system.FindAllByQuantity(1).Count);
        }

        [Test]
        public void GetEnumerator_Returns_AllProducts()
        {
            Mock<IProduct> product1 = new Mock<IProduct>();
            Mock<IProduct> product2 = new Mock<IProduct>();
            Mock<IProduct> product3 = new Mock<IProduct>();
            Mock<IProduct> product4 = new Mock<IProduct>();
            Mock<IProduct> product5 = new Mock<IProduct>();

            repo.Add(product1.Object);
            repo.Add(product2.Object);
            repo.Add(product3.Object);
            repo.Add(product4.Object);
            repo.Add(product5.Object);

            IList<IProduct> products = new List<IProduct>();

            products.Add(product1.Object);
            products.Add(product2.Object);
            products.Add(product3.Object);
            products.Add(product4.Object);
            products.Add(product5.Object);

            Assert.AreEqual(products, system.GetEnumerator());
        }
    }
}

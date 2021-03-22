//using DatabaseProblem;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private static int[] longArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        private Database testDatabase;

        [SetUp]
        public void Setup()
        {
            testDatabase = new Database();
        }

        [Test]
        public void When_ConstructorIsEmpty_ReturnZero()
        {
            testDatabase = new Database();
            int expected = 0;

            Assert.AreEqual(expected, testDatabase.Count);
        }

        [Test]
        public void When_ConstructorIsTooLong_ThrowException()
        {
            InvalidOperationException x = Assert.Throws<InvalidOperationException>(() => testDatabase = new Database(longArray));

            Assert.AreEqual(x.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Fetch_MustReturnArrayCorrectly()
        {
            testDatabase.Add(123);
            int[] arr = testDatabase.Fetch();

            Assert.IsTrue(arr.Contains(123));
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                testDatabase.Add(i);
            }

            int number = 1;
            InvalidOperationException x = Assert.Throws<InvalidOperationException>(() => testDatabase.Add(number));

            Assert.AreEqual(x.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Increase_DatabaseCount_WhenAddIsValid()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                testDatabase.Add(i);
            }

            Assert.AreEqual(n, testDatabase.Count);
        }

        [Test]
        public void When_RemovingFromEmptyDatabase_ThrowException()
        {
            testDatabase = new Database();

            InvalidOperationException x = Assert.Throws<InvalidOperationException>(() => testDatabase.Remove());

            Assert.AreEqual(x.Message, "The collection is empty!");
        }

        [Test]
        public void DecreaseCount_When_Remove()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                testDatabase.Add(i);
            }

            testDatabase.Remove();

            Assert.AreEqual(testDatabase.Count, n - 1);
        }

        [Test]
        public void Count_MustReturnCorrectly()
        {
            testDatabase = new Database();
            Assert.AreEqual(testDatabase.Count, 0);
        }

        [Test]
        public void Fetch_ReturnsCopyInsteadOfReference()
        {
            testDatabase.Add(1);
            testDatabase.Add(2);

            int[] firstArray = testDatabase.Fetch();

            testDatabase.Remove();

            int[] secondArray = testDatabase.Fetch();

            Assert.AreNotEqual(firstArray, secondArray);
        }

    }
}
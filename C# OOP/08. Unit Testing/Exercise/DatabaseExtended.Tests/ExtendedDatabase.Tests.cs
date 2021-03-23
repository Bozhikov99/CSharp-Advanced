using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace ExtendedDatabaseProblem
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person someoneWhoBreaksMyFckingCode;
        [SetUp]
        public void Setup()
        {
            someoneWhoBreaksMyFckingCode = new Person(999, "CodeBreaker");
            database = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_ThrowsException_WhenExceedingLimit()
        {
            Person[] array = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                array[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase(array));
        }

        [Test]
        public void AddRange_AddsInitialPeopleToTheDataBase()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }

            database = new ExtendedDatabase(arguments);

            Assert.That(database.Count, Is.EqualTo(arguments.Length));

            foreach (var person in arguments)
            {
                Person currentPerson = database.FindById(person.Id);
                Assert.AreEqual(currentPerson, person);
            }
        }

        [Test]
        public void Add_ThrowsException_WhenExceedingCapacity()                     //ok
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"User{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "UserName")));
        }

        [Test]
        public void Add_ThrowInvalidOperationException_WhenAddingExistingPerson()               //ok
        {
            string name = "Crash";
            database.Add(new Person(2, name));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(3,name)));
        }

        [Test]
        public void Add_ThrowInvalidOperationException_WhenAddingExistingID()                       //ok
        {
            long id = 1;
            database.Add(new Person(id, "Crash"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(id, "Name")));
        }

        [Test]
        public void Add_IncreasesCount()                                                            //ok
        {   
            database.Add(new Person(1, "User1"));
            database.Add(new Person(2, "User2"));

            int expectedResult = 2;

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void Remove_ThrowsInvalidOperationException_WhenDatabaseIsEmpty()                    //ok
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_RemovesLastElement()                                                     //ok
        {
            Person[] array = new Person[5];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Person(i, $"UserName{i}");
            }

            ExtendedDatabase database = new ExtendedDatabase(array);

            int count = database.Count;
            database.Remove();

            Assert.AreEqual(database.Count, count - 1);
            Assert.Throws<InvalidOperationException>(() => database.FindById(count));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]    
        public void FindByUsername_ThrowsException_WhenUsernameIsNullOrEmpty(string userName)        //ok
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(userName));
        }

        [Test]
        public void FindByUsername_ThrowsException_WhenUsernameIsNotContained()                     //ok
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Username"));
        }

        [Test]
        public void FindByUsername_FindsExpectedUser()                                              //ok
        {
            Person person = new Person(1, "UserName");

            database.Add(person);

            Person dbPerson = database.FindByUsername(person.UserName);

            Assert.AreEqual(person, dbPerson);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindById_ThrowsArgumentOutOfRangeException_WhenNumberIsNegative(long id)        //ok
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void FindById_ThrowsInvalidOperationException_WhenIdIsNotContained()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(1999));
        }

        [Test]
        public void FindById_ReturnsExpectedUser()                                                  //ok
        {
            Person person = new Person(1, "UserName");

            database.Add(person);

            Person dbPerson = database.FindById(person.Id);

            Assert.AreEqual(dbPerson, person);
        }
    }
}




//                          85/100
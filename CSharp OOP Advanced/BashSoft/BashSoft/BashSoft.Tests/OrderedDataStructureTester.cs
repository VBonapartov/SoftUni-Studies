namespace BashSoft.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using NUnit.Framework;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            // Assert
            Assert.AreEqual(16, this.names.Capacity, "Initial capacity have to be 16");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(20);

            // Assert
            Assert.AreEqual(20, this.names.Capacity, "Capacity must be equal to the provided one");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            // Assert
            Assert.AreEqual(30, this.names.Capacity, "Capacity must be equal to the provided one");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.AreEqual(16, this.names.Capacity, "Initial capacity have to be 16");
            Assert.AreEqual(0, this.names.Size, "Initial size have to be 0");
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            // Act
            this.names.Add("Nasko");

            // Assert
            Assert.AreEqual(1, this.names.Size, "Add didn't change the size");
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            // Act
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            // Assert
            Assert.AreEqual("Balkan", this.names[0], "Elements are not sorted");
            Assert.AreEqual("Georgi", this.names[1], "Elements are not sorted");
            Assert.AreEqual("Rosen", this.names[2], "Elements are not sorted");
        }

        [Test]
        public void TestAddingElementsMoreThanCapacityMustHaveCorrectSize()
        {
            // Arrange
            int expectedSize = 17;

            // Act
            for (int i = 0; i < 17; i++)
            {
                this.names.Add($"Gosho {i}");
            }

            // Assert
            Assert.AreEqual(expectedSize, this.names.Size, $"Size must be {expectedSize}");
        }

        [Test]
        public void TestAddingElementsMoreThanCapacityMustHaveCorrectCapacity()
        {
            // Arrange
            int expectedCapacity = 32;

            // Act
            for (int i = 0; i < 17; i++)
            {
                this.names.Add($"Gosho {i}");
            }

            // Assert
            Assert.AreEqual(expectedCapacity, this.names.Capacity, $"Capacity must be {expectedCapacity}");
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            // Arrange
            ICollection<string> items = new List<string>() { "Gosho", "Pesho" };

            // Act
            this.names.AddAll(items);

            // Assert
            Assert.IsTrue(this.names.Size == 2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            // Arrange
            ICollection<string> items = new List<string>() { "Gosho", null };

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(items));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            // Arrange
            string[] namesCollection = new string[] { "Borko", "Gosho", "Pesho" };

            ICollection<string> items = new List<string>()
            {
                "Pesho",
                "Borko",
                "Gosho"
            };

            // Act
            this.names.AddAll(items);

            // Assert
            CollectionAssert.AreEqual(namesCollection, this.names);
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            // Arrange
            this.names.Add("Gosho");

            // Act
            this.names.Remove("Gosho");

            // Assert
            Assert.AreEqual(0, this.names.Size, "Size is not decreased after removing an element");
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            // Arrange
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            // Act
            this.names.Remove("Ivan");

            // Assert
            Assert.IsTrue(!this.names.Any(x => x.Equals("Ivan")));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            // Arrange
            this.names.Add("Nasko");

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            // Arrange
            this.names.AddAll(new string[] { "Borko", "Gosho", "Pesho" });

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            // Arrange
            this.names.AddAll(new string[] { "Borko", "Gosho", "Pesho" });

            // Assert
            Assert.AreEqual("Borko, Gosho, Pesho", this.names.JoinWith(", "));
        }
    }
}

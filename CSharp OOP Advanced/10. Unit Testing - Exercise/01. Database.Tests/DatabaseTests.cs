using System;
using System.Linq;
using _01.Database;
using NUnit.Framework;

[TestFixture]
public class DatabaseTests
{
    private const int DatabaseCapacity = 16;

    private Database<int> database;

    [SetUp]
    public void TestInit()
    {
        this.database = new Database<int>();
    }

    [Test]
    public void DatabaseCapacityIsSixteen()
    {
        // Assert
        Assert.AreEqual(DatabaseCapacity, this.database.GetCapacity, $"Capacity must be {DatabaseCapacity}");
    }

    [Test]
    public void CanNotInitializeDatabaseWithCollectionOverCapacity()
    {
        // Arrange
        int[] testCollection = new int[DatabaseCapacity + 1];

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database = new Database<int>(testCollection));
    }

    [Test]
    public void EmptyDatabaseHasZeroCount()
    {
        // Assert
        Assert.AreEqual(0, this.database.Count, "Database count is not zero when it should be!");
    }

    [Test]
    [TestCase(3)]
    [TestCase(8)]
    [TestCase(16)]
    public void AddNumbersInDtabasseIncreasesCount(int numberOfAdditions)
    {
        // Act
        this.AddNumbers(numberOfAdditions);

        // Assert
        Assert.AreEqual(numberOfAdditions, this.database.Count, "Adding numbers doesn't update the count correctly");
    }

    [Test]
    [TestCase(3, 1)]
    [TestCase(8, 4)]
    [TestCase(16, 10)]
    public void RemoveNumbersFromDtabasseDecreasessCount(int numberOfAdditions, int numberOfRemovals)
    {
        // Act
        this.AddNumbers(numberOfAdditions);
        this.RemoveNumbers(numberOfRemovals);

        // Assert
        var expectedCount = numberOfAdditions - numberOfRemovals;
        Assert.AreEqual(expectedCount, this.database.Count, "Removing numbers doesn't update the count correctly");
    }

    [Test]
    public void FullDatabaseThrowsExceptionWhenAddingMoreItems()
    {
        // Act
        this.AddNumbers(DatabaseCapacity);

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database.Add(100));
    }

    [Test]
    public void RemovingItemFromEmptyDatabaseThrowsException()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database.Remove());
    }

    [Test]
    public void FetchEmptyDatabaseReturnsEmptyCollection()
    {
        // Arrange
        int[] numbers = new int[0];

        // Act
        int[] returnedCollection = this.database.Fetch();

        // Assert
        Assert.IsTrue(numbers.SequenceEqual(returnedCollection));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(8)]
    [TestCase(16)]
    public void FetchReturnsCorrectElementsFromDatabaseAfterAddition(int numberOfAdditions)
    {
        // Act
        this.AddNumbers(numberOfAdditions);
        int[] databaseContent = this.database.Fetch();

        // Assert
        for (int i = 0; i < numberOfAdditions; i++)
        {
            Assert.AreEqual(i, databaseContent[i]);
        }
    }

    private void AddNumbers(int numberOfAdditions)
    {
        for (int i = 0; i < numberOfAdditions; i++)
        {
            this.database.Add(i);
        }
    }

    private void RemoveNumbers(int numberOfRemovals)
    {
        for (int i = 0; i < numberOfRemovals; i++)
        {
            this.database.Remove();
        }
    }
}

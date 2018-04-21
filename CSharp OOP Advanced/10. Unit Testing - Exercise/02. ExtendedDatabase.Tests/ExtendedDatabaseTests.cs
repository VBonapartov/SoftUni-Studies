using System;
using NUnit.Framework;

[TestFixture]
public class ExtendedDatabaseTests
{
    private Database database;

    [SetUp]
    public void TestInitialization()
    {
        this.database = new Database();
    }

    [Test]
    public void DatabaseInitializeConstructorWithNull()
    {
        // Assert
        Assert.DoesNotThrow(() => this.database = new Database(null));
    }

    [Test]
    public void DatabaseInitializationConstructorWithCollectionOfPersons()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");
        IPerson secondPerson = new Person(2L, "SecondPerson");
        IPerson[] collectionOfPeople = new IPerson[] { firstPerson, secondPerson };

        // Act
        this.database = new Database(collectionOfPeople);

        // Assert
        Assert.AreEqual(2, this.database.Count, $"Constructor doesn't work with {typeof(IPerson)} as parameter correctly");
    }

    [Test]
    public void AddPersonToDatabase()
    {
        // Act
        this.database.Add(new Person(1, "Dummy"));

        // Assert
        Assert.AreEqual(1, this.database.Count, "Adding user to database doesn't work");
    }

    [Test]
    public void RemovePersonFromDataBase()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");
        this.database.Add(firstPerson);

        // Act
        this.database.Remove();

        // Assert
        Assert.AreEqual(0, this.database.Count, $"Remove {typeof(IPerson)} doesn't work");
    }

    [Test]
    public void AddUserWithDuplicatingUsername()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");

        // Act
        this.database.Add(firstPerson);

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(2L, "FirstPerson")));
    }

    [Test]
    public void AddUserWithDuplicatingId()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");

        // Act
        this.database.Add(firstPerson);

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(1L, "SecondPerson")));
    }

    [Test]
    public void FindExistingPersonById()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");
        this.database.Add(firstPerson);

        // Act
        IPerson person = this.database.FindById(1);

        // Assert
        Assert.IsNotNull(person);
    }

    [Test]
    public void CannotFindUnexistentId()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");
        this.database.Add(firstPerson);

        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database.FindById(2));
    }

    [Test]
    public void CannotFindNegativeId()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
    }

    [Test]
    public void FindExistingPersonByUsername()
    {
        // Arrange
        IPerson firstPerson = new Person(1L, "FirstPerson");
        this.database.Add(firstPerson);

        // Act
        IPerson person = this.database.FindByUsername("FirstPerson");

        // Assert
        Assert.IsNotNull(person);
    }

    [Test]
    public void FindPersonWithNullValueForUsername()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
    }

    [Test]
    public void FindPersonWithNonExistingUsernameThrowsException()
    {
        // Assert
        Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("ThirdPerson"));
    }
}

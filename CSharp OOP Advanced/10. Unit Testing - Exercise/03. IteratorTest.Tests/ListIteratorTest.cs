using System;
using NUnit.Framework;

[TestFixture]
public class ListIteratorTest
{
    private ListIterator listIterator;
    private string[] initElements;

    [SetUp]
    public void TestInit()
    {
        this.initElements = new string[] { "String1", "String2", "String3" };
        this.listIterator = new ListIterator(this.initElements);
    }

    [Test]
    public void CreateWithNullParameter()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => this.listIterator = new ListIterator(null));
    }

    [Test]
    public void HasNextReturnsTrueIfThereIsNextElement()
    {
        // Act
        this.listIterator.Move();

        // Assert
        Assert.IsTrue(this.listIterator.HasNext());
    }

    [Test]
    public void HasNextReturnsFalseIfThereIsNotNextElement()
    {
        // Act
        this.listIterator.Move();
        this.listIterator.Move();

        // Assert
        Assert.IsFalse(this.listIterator.HasNext());
    }

    [Test]
    public void MoveReturnsTrueWhenSuccessful()
    {
        // Assert
        Assert.AreEqual(true, this.listIterator.Move());
        Assert.AreEqual(true, this.listIterator.Move());
    }

    [Test]
    public void MoveReturnsFalseWhenThereIsNoMoreElements()
    {
        // Act
        this.listIterator.Move();
        this.listIterator.Move();

        // Assert
        Assert.AreEqual(false, this.listIterator.Move());
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void PrintReturnsCurrentElement(int elementIndex)
    {
        // Act
        for (int i = 0; i < elementIndex; i++)
        {
            this.listIterator.Move();
        }

        // Assert
        Assert.AreEqual(this.initElements[elementIndex], this.listIterator.Print(), "Print doesn't return correcr element");
    }

    [Test]
    public void PrintWithEmptyListThrowsException()
    {
        // Arrange
        this.listIterator = new ListIterator(new string[0]);

        // Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.listIterator.Print());
        Assert.AreEqual("Invalid Operation!", ex.Message, "Incorrect exception message when attempting to print over empty iterator");
    }
}

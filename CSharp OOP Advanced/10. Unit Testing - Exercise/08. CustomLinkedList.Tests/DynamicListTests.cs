using System;
using global::CustomLinkedList;
using NUnit.Framework;

[TestFixture]
public class DynamicListTests
{
    private DynamicList<int> dynamicList;

    [SetUp]
    public void TestInit()
    {
        this.dynamicList = new DynamicList<int>();
    }

    [Test]
    public void NewDynamicListCountIsZero()
    {
        // Assert
        Assert.AreEqual(0, this.dynamicList.Count);
    }

    [Test]
    public void AddToDynamicListShouldIncreaseCollectionCount()
    {
        // Act
        this.dynamicList.Add(1);

        // Assert
        Assert.AreEqual(1, this.dynamicList.Count, "Adding an element doesn't affect the collection's count");
    }

    public void AddShouldSaveTheElementInTheDynamicList()
    {
        // Act
        this.dynamicList.Add(5);

        // Assert
        Assert.AreEqual(5, this.dynamicList[0], "Element is not the same as the one added");
    }

    [Test]
    public void CallElementWithNegativeIndexThrowsException()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => { int test = this.dynamicList[-1]; }, "Index is less than zero");
    }

    [Test]
    public void CallElementWithIndexAboveTheRangeThrowsException()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => { int test = this.dynamicList[1]; }, "Index is greater than the range of the collection");
    }

    [Test]
    [TestCase(-1)]
    [TestCase(1)]
    [TestCase(8)]
    public void RemoveAtInvalidIndexThrowsException(int index)
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(index));
    }

    [Test]
    public void RemoveExistingElementByValueShoulReturnTheIndexOfElement()
    {
        // Arrange
        this.dynamicList.Add(10);

        // Act
        int indexRemoveElement = this.dynamicList.Remove(10);

        // Assert
        Assert.AreEqual(0, indexRemoveElement);
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void RemoveNonExistentElementByValueShouldReturnNegativeValue(int value)
    {
        // Assert
        Assert.AreEqual(-1, this.dynamicList.Remove(value));
    }

    [Test]
    public void IndexOfShouldReturnTheIndexPointingAtTheCurrentLocationOfTheElement()
    {
        // Arrange
        this.dynamicList.Add(10);
        this.dynamicList.Add(20);

        // Act
        int elementIndex = this.dynamicList.IndexOf(20);

        // Assert
        Assert.AreEqual(1, elementIndex, "Returned index is not correct");
    }

    [Test]
    public void IndexOfShouldReturnNegativeIntegerIfTheGivenElementDoesNotExists()
    {
        // Arrange
        this.dynamicList.Add(10);
        this.dynamicList.Add(20);

        // Act
        int elementIndex = this.dynamicList.IndexOf(100);

        // Assert
        Assert.AreEqual(-1, elementIndex, "Returned index is not negative");
    }

    [Test]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(30)]
    public void ContainsShouldReturnTrueForExistingElementsWhenSearchedByValue(int value)
    {
        // Arrange
        this.dynamicList.Add(value);

        // Assert
        Assert.IsTrue(this.dynamicList.Contains(value), "Contains returns false for existing element");
    }

    [Test]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(30)]
    public void ContainsShouldReturnFalseForNonExistentElementsWhenSearchedByValue(int value)
    {
        // Assert
        Assert.IsFalse(this.dynamicList.Contains(value), "Contains returns true for non-existent element");
    }

    [Test]
    public void RemoveShouldDeleteElementFromDynamicList()
    {
        // Arrange
        this.dynamicList.Add(50);

        // Act
        this.dynamicList.Remove(50);

        // Assert
        Assert.AreEqual(-1, this.dynamicList.IndexOf(50), "Removed element not working correctly");
    }
}

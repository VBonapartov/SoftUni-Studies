using System.Linq;
using NUnit.Framework;

[TestFixture]
public class BubbleTests
{
    private Bubble bubble;
    private int[] sortedNumbers;

    [SetUp]
    public void TestInit()
    {
        // Arrange
        this.bubble = new Bubble();
        this.sortedNumbers = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 19 };
    }

    [Test]
    [TestCase(11, 19, 18, 17, 12, 16, 13, 14, 15)]
    [TestCase(17, 11, 16, 12, 19, 18, 15, 14, 13)]
    public void BubbleCanSortNumbers(params int[] numbersToSort)
    {
        // Act
        this.bubble.Sort(numbersToSort);

        // Assert
        Assert.IsTrue(this.sortedNumbers.SequenceEqual(numbersToSort));
        //CollectionAssert.AreEqual(sortedNumbers, numbersToSort);
    }
}

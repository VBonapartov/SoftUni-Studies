using System;
using Moq;
using NUnit.Framework;

[TestFixture]
public class AddDaysTests
{
    private Mock<IDateTime> time;

    [SetUp]
    public void TestInit()
    {
        this.time = new Mock<IDateTime>();
    }

    [Test]
    public void GetCurrentTime()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, DateTime.Now);

        // Assert
        Assert.AreEqual(DateTime.Now.ToShortTimeString(), this.time.Object.Now.ToShortTimeString());
    }

    [Test]
    public void AddADayInTheMiddleOfTheMonth()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 16));

        // Act
        DateTime moqDateTime = this.time.Object.Now.AddDays(1);

        // Assert
        Assert.AreEqual(17, moqDateTime.Day);
    }

    [Test]
    public void AddDayThatJumpsToNextMonth()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 31));

        // Act
        DateTime moqDateTime = this.time.Object.Now.AddDays(1);

        // Assert
        Assert.IsTrue(moqDateTime.Month == 9 && moqDateTime.Day == 1);
    }

    [Test]
    public void AddNegativeDays()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 31));

        // Act
        DateTime moqDateTime = this.time.Object.Now.AddDays(-10);

        // Assert
        Assert.IsTrue(moqDateTime.Month == 8 && moqDateTime.Day == 21);
    }

    [Test]
    public void AddNegativeDaysThatJumpToPreviousMonth()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 1));

        // Act
        DateTime moqDateTime = this.time.Object.Now.AddDays(-1);

        // Assert
        Assert.IsTrue(moqDateTime.Month == 7 && moqDateTime.Day == 31);
    }

    [Test]
    public void AddDayToLeapYear()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, new DateTime(2008, 02, 28));

        // Act
        DateTime moqDateTime = this.time.Object.Now.AddDays(1);

        // Assert
        Assert.IsTrue(moqDateTime.Month == 2 && moqDateTime.Day == 29);
    }

    [Test]
    public void AddDayToNonLeapYear()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, new DateTime(1900, 02, 28));

        // Act
        DateTime moqDateTime = this.time.Object.Now.AddDays(1);

        // Assert
        Assert.IsTrue(moqDateTime.Month == 3 && moqDateTime.Day == 1);
    }

    [Test]
    public void AddDayToDateTimeMinValue()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, DateTime.MinValue);

        // Assert
        Assert.DoesNotThrow(() => this.time.Object.Now.AddDays(1));
    }

    [Test]
    public void SubtractDayToDateTimeMinValue()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, DateTime.MinValue);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => this.time.Object.Now.AddDays(-1));
    }

    [Test]
    public void AddDayToDateTimeMaxValue()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, DateTime.MaxValue);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => this.time.Object.Now.AddDays(1));
    }

    [Test]
    public void SubtractDayToDateTimeMaxValue()
    {
        // Arrange
        this.time.SetupProperty(x => x.Now, DateTime.MaxValue);

        // Assert
        Assert.DoesNotThrow(() => this.time.Object.Now.AddDays(-1));
    }
}

using System;
using System.Reflection;
using _10.TirePressureMonitoring.Models;
using Moq;
using NUnit.Framework;

[TestFixture]
public class AlarmTests
{
    private Mock<Random> randomMock;

    [SetUp]
    public void Initialize()
    {
        this.randomMock = new Mock<Random>();
    }

    [Test]
    [TestCase(0.92)]
    [TestCase(3.12)]
    [TestCase(7.28)]
    public void AlarmShouldReturnsTrueIfPressureValueIsMoreThanHighPressureThreshold(double pressureSample)
    {
        // Arrange
        randomMock.Setup(x => x.NextDouble()).Returns(pressureSample);

        // Act
        Alarm alarm = SetAlarm(randomMock);
        alarm.Check();

        // Assert
        Assert.That(alarm.AlarmOn, Is.EqualTo(true), "Alarm not work correctly!");
    }

    [Test]
    [TestCase(0.4)]
    [TestCase(0.23)]
    [TestCase(0.07)]
    public void AlarmShouldReturnsTrueIfPressureValueIsLessThanLowPressureThreshold(double pressureSample)
    {
        // Arrange
        randomMock.Setup(x => x.NextDouble()).Returns(pressureSample);

        // Act
        Alarm alarm = SetAlarm(randomMock);
        alarm.Check();

        // Assert
        Assert.That(alarm.AlarmOn, Is.EqualTo(true), "Alarm not work correctly!");
    }

    [Test]
    [TestCase(0.409)]
    [TestCase(0.727)]
    [TestCase(0.9)]
    public void AlarmShouldReturnsFalseIfPressureValueBetweenLowPressureThresholdAndHighPressureThreshold(double pressureSample)
    {
        // Arrange        
        randomMock.Setup(x => x.NextDouble()).Returns(pressureSample);

        // Act
        Alarm alarm = SetAlarm(randomMock);
        alarm.Check();

        // Assert
        Assert.That(alarm.AlarmOn, Is.EqualTo(false), "Alarm not work correctly!");
    }

    private Alarm SetAlarm(Mock<Random> randomMock)
    {
        Sensor sensor = new Sensor();
        FieldInfo randomField = sensor.GetType().GetField("_randomPressureSampleSimulator", BindingFlags.Instance | BindingFlags.NonPublic);
        randomField.SetValue(sensor, randomMock.Object);

        Alarm alarm = new Alarm();
        FieldInfo sensorField = alarm.GetType().GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
        sensorField.SetValue(alarm, sensor);

        return alarm;
    }
}

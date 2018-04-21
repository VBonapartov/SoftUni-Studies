using System;
using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int AttackPoints = 10;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;

    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        // Arrange

        // Act
        this.dummy.TakeAttack(AttackPoints);

        // Assert
        Assert.AreEqual(0, this.dummy.Health, "Dummy doesn't lose health if attacked");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        // Arrange

        // Act
        this.dummy.TakeAttack(AttackPoints);

        // Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(AttackPoints));
        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        // Arrange

        // Act
        this.dummy.TakeAttack(AttackPoints);

        // Assert
        Assert.AreEqual(10, this.dummy.GiveExperience(), "Dead dummy doesn't give experience");
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        // Arrange

        // Act

        // Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
    }
}

using System;
using System.Collections.Generic;
using NUnit.Framework;
using RecyclingStation.BusinessLayer.Attributes;
using RecyclingStation.BusinessLayer.Strategies;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

[TestFixture]
public class StrategyHolderTests
{
    private Dictionary<Type, IGarbageDisposalStrategy> strategies;
    private IStrategyHolder strategyHolder;

    [SetUp]
    public void TestInit()
    {
        this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        this.strategyHolder = new StrategyHolder(this.strategies);
    }

    [Test]
    public void ConstructorShouldInitializeWithEmptyCollection()
    {
        // Assert
        Assert.DoesNotThrow(() => new StrategyHolder(this.strategies),
                            "Strategy Holder was not initialized with an empty collection!");
    }

    [Test]
    public void ConstructorShouldInitializeWithInputStrategies()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();

        // Assert
        Assert.DoesNotThrow(() => new StrategyHolder(this.strategies), "Strategy Holder was not initialized with input strategies!");
    }

    [Test]
    public void GetDisposalStrategiesShouldReturnNotNullCollection()
    {
        // Act
        var strategies = this.strategyHolder.GetDisposalStrategies;

        // Assert
        Assert.AreNotEqual(null, strategies, "No strategies were fetched!");
    }

    [Test]
    public void GetDisposalStrategiesShouldReturnCollectionOfTypeIReadOnlyDictionary()
    {
        // Act
        var strategiesCollection = this.strategyHolder.GetDisposalStrategies;
        Type[] strategiesInterfaces = strategiesCollection.GetType().GetInterfaces();

        // Assert
        Assert.Contains(typeof(IReadOnlyDictionary<Type, IGarbageDisposalStrategy>),
                        strategiesInterfaces,
                        "Fetched strategies collection was not IReadOnlyDictionary!");

        Assert.IsInstanceOf(typeof(IReadOnlyDictionary<Type, IGarbageDisposalStrategy>),
                            strategiesCollection,
                            "Fetched strategies collection was not IReadOnlyDictionary!");
    }

    [Test]
    public void GetDisposalStrategiesCountShouldEqualInputCount()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();
        int inputStrategiesCount = this.strategies.Count;
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        int fetchedStrategiesCount = this.strategyHolder.GetDisposalStrategies.Count;

        // Assert
        Assert.AreEqual(inputStrategiesCount, fetchedStrategiesCount,
                        "Fetched strategies count did not match input strategies count!");
    }

    [Test]
    public void GetDisposalStrategiesShouldMatchTheInputStrategies()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        var fetchedStrategies = this.strategyHolder.GetDisposalStrategies;

        // Assert
        CollectionAssert.AreEqual(this.strategies, fetchedStrategies,
                                  "Fetched strategies did not match input strategies!");
    }

    [Test]
    public void AddStrategyWithNonExistingAttributeTypeShouldBeSuccessful()
    {
        // Act
        bool success = this.strategyHolder.AddStrategy(typeof(RecyclableStrategyAttribute),
                                                       new RecyclableGarbageDisposalStrategy());
        // Assert
        Assert.AreEqual(true, success, "Strategy was not added!");
    }

    [Test]
    public void AddStrategyWithNonExistingAttributeTypeShouldIncreaseStrategiesCount()
    {
        // Act
        bool success = this.strategyHolder.AddStrategy(typeof(RecyclableStrategyAttribute),
                                                       new RecyclableGarbageDisposalStrategy());
        // Assert
        Assert.AreEqual(1, this.strategyHolder.GetDisposalStrategies.Count, "Strategy count did not increase!");
    }

    [Test]
    public void AddStrategyWithDifferentAttributeTypesShouldBeSuccessful()
    {
        // Act
        bool success1 = this.strategyHolder.AddStrategy(typeof(RecyclableStrategyAttribute),
                                                        new RecyclableGarbageDisposalStrategy());
        bool success3 = this.strategyHolder.AddStrategy(typeof(BurnableStrategyAttribute),
                                                        new BurnableGarbageDisposalStrategy());
        bool success2 = this.strategyHolder.AddStrategy(typeof(StorableStrategyAttribute),
                                                        new StorableGarbageDisposalStrategy());
        // Assert
        Assert.AreEqual(true, success1);
        Assert.AreEqual(true, success2);
        Assert.AreEqual(true, success3);
    }

    [Test]
    public void AddStrategyWithDifferentAttributeTypesShouldIncreaseStrategiesCount()
    {
        // Act
        bool success1 = this.strategyHolder.AddStrategy(typeof(RecyclableStrategyAttribute),
                                                        new RecyclableGarbageDisposalStrategy());
        bool success3 = this.strategyHolder.AddStrategy(typeof(BurnableStrategyAttribute),
                                                        new BurnableGarbageDisposalStrategy());
        bool success2 = this.strategyHolder.AddStrategy(typeof(StorableStrategyAttribute),
                                                        new StorableGarbageDisposalStrategy());
        // Assert
        Assert.AreEqual(3, this.strategyHolder.GetDisposalStrategies.Count, "Different strategies were not added!");
    }

    [Test]
    public void AddStrategyWithTheSameAttributeTypeShouldAddOnlyOnce()
    {
        // Act
        for (int i = 0; i < 3; i++)
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableStrategyAttribute), new RecyclableGarbageDisposalStrategy());
        }

        // Assert
        Assert.AreEqual(1, this.strategyHolder.GetDisposalStrategies.Count, "Strategy was added to attribute more than once!");
    }

    [Test]
    public void AddStrategyWithInvalidAttributeTypeShouldBeUnsuccessful()
    {
        // Act
        bool success = this.strategyHolder.AddStrategy(typeof(string), new RecyclableGarbageDisposalStrategy());

        // Assert
        Assert.AreEqual(false, success, "Strategy with invalid attribute type was added!");
    }

    [Test]
    public void RemoveStrategyWithExisingAttributeTypeShouldBeSuccessful()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        bool success = this.strategyHolder.RemoveStrategy(typeof(RecyclableStrategyAttribute));

        // Assert
        Assert.AreEqual(true, success, "Existing strategy was not removed!");
    }

    [Test]
    public void RemoveStrategyWithSeveralExistingAttributeTypesShouldBeSuccessfull()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        bool success1 = this.strategyHolder.RemoveStrategy(typeof(RecyclableStrategyAttribute));
        bool success2 = this.strategyHolder.RemoveStrategy(typeof(BurnableStrategyAttribute));
        bool success3 = this.strategyHolder.RemoveStrategy(typeof(StorableStrategyAttribute));

        // Assert
        Assert.AreEqual(true, success1, "Existing strategy was not removed!");
        Assert.AreEqual(true, success2, "Existing strategy was not removed!");
        Assert.AreEqual(true, success3, "Existing strategy was not removed!");
    }

    [Test]
    public void RemoveStrategyWithExistingAttributeTypesShouldDecreaseStrategiesCount()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        bool success = this.strategyHolder.RemoveStrategy(typeof(RecyclableStrategyAttribute));

        // Assert
        Assert.AreEqual(2, this.strategyHolder.GetDisposalStrategies.Count,
                        "Removing existing strategies did not decrease strategies count!");
    }

    [Test]
    public void RemoveStrategyWithSeveralExistingAttributeTypesShouldDecreaseStrategiesCount()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategies[typeof(BurnableStrategyAttribute)] = new BurnableGarbageDisposalStrategy();
        this.strategies[typeof(StorableStrategyAttribute)] = new StorableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        bool success1 = this.strategyHolder.RemoveStrategy(typeof(RecyclableStrategyAttribute));
        bool success2 = this.strategyHolder.RemoveStrategy(typeof(BurnableStrategyAttribute));
        bool success3 = this.strategyHolder.RemoveStrategy(typeof(StorableStrategyAttribute));

        // Assert
        Assert.AreEqual(0, this.strategyHolder.GetDisposalStrategies.Count,
                        "Removing existing strategies did not decrease strategies count!");
    }

    [Test]
    public void RemoveStrategyWithNonExistingAttributeTypeShouldBeUnsuccessful()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        bool success = this.strategyHolder.RemoveStrategy(typeof(StorableGarbageDisposalStrategy));

        // Assert
        Assert.AreEqual(false, success, "Removing strategy with non-exising attribute type was unsuccessful!");
    }

    [Test]
    public void RemoveStrategyWithInvalidAttributeTypeShouldBeUnsuccessful()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);

        // Act
        bool success = this.strategyHolder.RemoveStrategy(typeof(string));

        // Assert
        Assert.AreEqual(false, success, "Removing strategy with invalid attribute type was unsuccessful!");
    }

    [Test]
    public void RemoveStrategyWithNonExistingAttributeTypeShouldNotChangeStrategiesCount()
    {
        // Arrange
        this.strategies[typeof(RecyclableStrategyAttribute)] = new RecyclableGarbageDisposalStrategy();
        this.strategyHolder = new StrategyHolder(this.strategies);
        int initialStrategiesCount = this.strategyHolder.GetDisposalStrategies.Count;

        // Act
        bool success = this.strategyHolder.RemoveStrategy(typeof(StorableGarbageDisposalStrategy));

        // Assert
        Assert.AreEqual(initialStrategiesCount,
                        this.strategyHolder.GetDisposalStrategies.Count,
                        "Strategies count changed upon removing a non-existing strategy!");
    }
}

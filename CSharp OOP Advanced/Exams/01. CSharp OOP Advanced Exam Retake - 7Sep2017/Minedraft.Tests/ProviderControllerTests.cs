using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void Init()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void RegisterAddNewProviderToProvidersCollection()
    {
        // Arrange
        List<string> args = new List<string> { "Pressure", "40", "100" };

        // Act
        this.providerController.Register(args);

        // Assert
        int countOfProviders = this.GetProviders().Count;
        Assert.That(countOfProviders, Is.EqualTo(1), "Count of registered providers is not correct!");
    }

    [Test]
    public void ProduceShouldAddProvidersEnergyToTotalEnergyProduced()
    {
        // Arrange
        List<string> args = new List<string> { "Pressure", "40", "100" };
        List<string> args1 = new List<string> { "Solar", "80", "100" };
        this.providerController.Register(args);
        this.providerController.Register(args1);

        // Act
        this.providerController.Produce();

        // Assert
        double actualTotalEnergyProduced = this.providerController.TotalEnergyProduced;
        Assert.That(actualTotalEnergyProduced, Is.EqualTo(300));
    }

    [Test]
    public void ProduceRemoveBrokenProviders()
    {
        // Arrange
        List<string> args = new List<string> { "Pressure", "40", "45" };
        this.providerController.Register(args);

        // Act
        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        // Assert
        int actualAliveProvidersCount = this.GetProviders().Count;
        Assert.That(actualAliveProvidersCount, Is.EqualTo(0), "Alive providers count is not correct");
    }

    private List<IEntity> GetProviders()
    {
        List<IEntity> entities = new List<IEntity>();

        var providerEntitites = this.providerController
                                                .GetType()
                                                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                .FirstOrDefault(t => t.Name == "Entities");

        var providers = (IReadOnlyCollection<IEntity>)providerEntitites.GetValue(this.providerController);

        entities.AddRange(providers);
        return entities;
    }
}
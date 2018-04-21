using NUnit.Framework;

[TestFixture]
public class MissionControllerTests
{
    private IArmy army;
    private IWareHouse warehouse;
    private MissionController missionController;

    [SetUp]
    public void TestInit()
    {
        this.army = new Army();
        this.warehouse = new WareHouse();

        this.missionController = new MissionController(this.army, this.warehouse);
    }

    [Test]
    public void PerformMissionEnqueuesMissionCorrectly()
    {
        // Arrange
        Easy mission = new Easy(50);

        // Act
        this.missionController.PerformMission(mission);

        // Assert
        Assert.AreEqual(1, this.missionController.Missions.Count);
    }

    [Test]
    public void PerformMissionWithoutEnoughSoldiersReturnsCorrectMessage()
    {
        // Arrange
        Hard mission = new Hard(20);

        // Act
        var message = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual($"Mission on hold - {mission.Name}", message);
    }

    [Test]
    public void PerformMissionCannotEnqueMoreThanThreeMissionsOnHold()
    {
        // Arrange
        Hard mission1 = new Hard(20);
        Hard mission2 = new Hard(20);
        Hard mission3 = new Hard(20);
        Hard mission4 = new Hard(20);

        // Act
        this.missionController.PerformMission(mission1);
        this.missionController.PerformMission(mission2);
        this.missionController.PerformMission(mission3);
        this.missionController.PerformMission(mission4);

        // Assert
        Assert.AreEqual(3, this.missionController.Missions.Count);
    }

    [Test]
    public void PerformMissionWithEnoughSoldiersReturnsCorrectMessage()
    {
        // Arrange
        Easy mission = new Easy(20);

        this.warehouse.AddAmmunitions("Gun", 10);
        this.warehouse.AddAmmunitions("AutomaticMachine", 10);
        this.warehouse.AddAmmunitions("Helmet", 10);

        Ranker soldier3 = new Ranker("Soldier 3", 30, 50, 50);
        this.army.AddSoldier(soldier3);
        this.warehouse.EquipArmy(this.army);

        // Act
        string message = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual($"Mission completed - {mission.Name}", message);
    }

    [Test]
    public void PerformMissionSuccessfullyIncreasesSucceededMissionsCounter()
    {
        // Arrange
        Easy mission = new Easy(20);

        this.warehouse.AddAmmunitions("Gun", 10);
        this.warehouse.AddAmmunitions("AutomaticMachine", 10);
        this.warehouse.AddAmmunitions("Helmet", 10);

        Ranker soldier3 = new Ranker("Soldier 3", 30, 50, 50);
        this.army.AddSoldier(soldier3);
        this.warehouse.EquipArmy(this.army);

        // Act
        string message = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual(1, this.missionController.SuccessMissionCounter);
    }

    [Test]
    public void PerformMissionDeclinesFirstWaitingMissionWhenTheWaitingOnesAreMoreThanThree()
    {
        // Arrange
        Hard mission = new Hard(20);
        this.missionController.PerformMission(mission).Trim();
        this.missionController.PerformMission(mission).Trim();
        this.missionController.PerformMission(mission).Trim();

        // Act
        string message = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.IsTrue(message.StartsWith($"Mission declined - {mission.Name}"));
    }

    [Test]
    public void FailMissionsOnHoldIncreasesFailedMissionCounterCorrectly()
    {
        // Arrange
        Hard mission = new Hard(20);
        this.missionController.PerformMission(mission).Trim();

        // Act
        this.missionController.FailMissionsOnHold();

        // Assert
        Assert.AreEqual(1, this.missionController.FailedMissionCounter);
    }

    [Test]
    public void FailedMissionCounterDisplaysCorrectlyIfNone()
    {
        // Arrange 
        Easy mission = new Easy(0);

        // Act
        this.missionController.PerformMission(mission);

        // Assert
        Assert.AreEqual(0, this.missionController.FailedMissionCounter);
    }

    [Test]
    public void FailIfMoreThanThreeMissions()
    {
        // Arrange
        this.missionController.Missions.Enqueue(new Easy(0));
        this.missionController.Missions.Enqueue(new Easy(0));
        this.missionController.Missions.Enqueue(new Easy(0));

        // Act
        this.missionController.PerformMission(new Easy(0));

        // Assert
        Assert.AreEqual(this.missionController.FailedMissionCounter, 1);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    #region constants

    private const string CommandPrefix = "Parse";
    private const string CommandSuffix = "Command";
    private const string RegenerateCommand = "Regenerate";
    private const string ResultOutput = "Results:";
    private const string SoldiersOutput = "Soldiers:";

    #endregion

    #region fields

    private readonly MissionController missionController;
    private readonly SoldierFactory soldiersFactory;
    private readonly MissionFactory missionFactory;
    private readonly IWriter writer;
    private IWareHouse wareHouse;
    private IArmy army;
    
    #endregion

    public GameController(IWriter writer)
    {
        this.writer = writer;
        this.wareHouse = new WareHouse();        
        this.army = new Army();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldiersFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
    }

    public void ProcessCommand(string input)
    {
        List<string> data = input.Split().ToList();
        string commandType = data[0];
        data.RemoveAt(0);

        string commandFullName = CommandPrefix + commandType + CommandSuffix;

        try
        {
            this.GetType()
                .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, new object[] { data });
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    public void ProduceSummury()
    {
        List<ISoldier> orderedArmy = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();        

        this.writer.StoreMessage(ResultOutput);
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));
        this.writer.StoreMessage(SoldiersOutput);

        foreach (ISoldier soldier in orderedArmy)
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }

    private void ParseWareHouseCommand(IList<string> data)
    {
        string name = data[0];
        int quantity = int.Parse(data[1]);
        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void ParseSoldierCommand(IList<string> data)
    {
        if (data[0] == RegenerateCommand)
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            this.AddSoldierToArmy(data);
        }
    }

    private void AddSoldierToArmy(IList<string> data)
    {
        string type = data[0];
        string name = data[1];
        int age = int.Parse(data[2]);
        double experience = double.Parse(data[3]);
        double endurance = double.Parse(data[4]);

        ISoldier soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void ParseMissionCommand(IList<string> data)
    {
        string difficultyLevel = data[0];
        double scoreToComplete = double.Parse(data[1]);
        IMission mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.StoreMessage(this.missionController.PerformMission(mission));
    }
}
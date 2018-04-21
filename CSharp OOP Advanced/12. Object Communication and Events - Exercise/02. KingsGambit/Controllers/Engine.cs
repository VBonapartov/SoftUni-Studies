using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private King king;
    private List<Soldier> soldiers;

    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.soldiers = new List<Soldier>();
    }

    public void Run()
    {
        this.BuildKingdom();
        this.ExecuteCommands();
    }

    private void BuildKingdom()
    {
        string kingName = this.reader.ReadLine();
        this.king = new King(kingName, this.writer);

        string[] royalGuardNames = this.reader.ReadLine().Split(' ');
        foreach (string name in royalGuardNames)
        {
            RoyalGuard royalGuard = new RoyalGuard(name, this.writer);
            this.soldiers.Add(royalGuard);
            this.king.UnderAttack += royalGuard.KingUnderAttack;
        }

        string[] footmanNames = this.reader.ReadLine().Split(' ');
        foreach (string name in footmanNames)
        {
            Footman footman = new Footman(name, this.writer);
            this.soldiers.Add(footman);
            this.king.UnderAttack += footman.KingUnderAttack;
        }
    }

    private void ExecuteCommands()
    {
        string[] command = this.reader.ReadLine().Split(' ');

        while (!command[0].Equals("End"))
        {
            switch (command[0])
            {
                case "Attack":
                    this.king.OnUnderAttack();
                    break;

                case "Kill":
                    this.RemoveDeadSoldier(command[1]);
                    break;

                default:
                    break;
            }

            command = this.reader.ReadLine().Split(' ');
        }
    }

    private void RemoveDeadSoldier(string soldierName)
    {
        Soldier soldier = this.soldiers.FirstOrDefault(s => s.Name.Equals(soldierName));
        this.king.UnderAttack -= soldier.KingUnderAttack;
        this.soldiers.Remove(soldier);
    }
}

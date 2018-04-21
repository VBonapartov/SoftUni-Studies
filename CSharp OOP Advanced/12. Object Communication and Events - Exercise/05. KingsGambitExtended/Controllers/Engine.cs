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

        this.soldiers.ForEach(s => s.SoldierKilled += this.OnSoldierKilled);
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
                    string soldierName = command[1];
                    Soldier soldier = this.soldiers.FirstOrDefault(s => s.Name.Equals(soldierName));
                    soldier.TakeAttack();
                    break;

                default:
                    break;
            }

            command = this.reader.ReadLine().Split();
        }
    }

    private void OnSoldierKilled(object source, KillEventArgs args)
    {
        this.king.UnderAttack -= args.Soldier.KingUnderAttack;
        this.soldiers.Remove(args.Soldier);
    }
}

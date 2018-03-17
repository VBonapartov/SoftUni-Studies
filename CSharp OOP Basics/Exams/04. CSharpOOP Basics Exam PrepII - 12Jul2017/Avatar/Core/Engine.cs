using System;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private NationsBuilder nationsBuilder;

    public Engine(NationsBuilder nationsBuilder, IReader reader, IWriter writer)
    {
        this.nationsBuilder = nationsBuilder;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        string result = string.Empty;

        while (true)
        {
            string[] cmdArgs = this.reader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(cmdArgs.Skip(1).ToList());
                    break;

                case "Monument":
                    this.nationsBuilder.AssignMonument(cmdArgs.Skip(1).ToList());
                    break;

                case "Status":
                    result = this.nationsBuilder.GetStatus(cmdArgs[1]);
                    this.writer.WriteLine(result);
                    break;

                case "War":
                    this.nationsBuilder.IssueWar(cmdArgs[1]);
                    break;

                case "Quit":
                    result = this.nationsBuilder.GetWarsRecord();
                    this.writer.WriteLine(result);
                    return;
            }
        }
    }
}
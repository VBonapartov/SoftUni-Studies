using System;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private CarManager carManager;

    public Engine(CarManager carManager, IReader reader, IWriter writer)
    {
        this.carManager = carManager;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        string input = this.reader.ReadLine();

        string result = string.Empty;

        while (input != "Cops Are Here")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "register":
                    carManager.Register(int.Parse(tokens[1]), tokens[2], tokens[3], tokens[4], int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]), int.Parse(tokens[8]), int.Parse(tokens[9]));
                    break;

                case "check":
                    result = this.carManager.Check(int.Parse(tokens[1]));
                    this.writer.WriteLine(result);
                    break;

                case "open":
                    if (tokens[2] == "TimeLimit" || tokens[2] == "Circuit")
                    {
                        carManager.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]), int.Parse(tokens[6]));
                    }
                    else
                    {
                        carManager.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]));
                    }
                    break;

                case "participate":
                    carManager.Participate(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;

                case "start":
                    result = carManager.Start(int.Parse(tokens[1]));
                    this.writer.WriteLine(result);
                    break;

                case "park":
                    carManager.Park(int.Parse(tokens[1]));
                    break;

                case "unpark":
                    carManager.Unpark(int.Parse(tokens[1]));
                    break;

                case "tune":
                    carManager.Tune(int.Parse(tokens[1]), tokens[2]);
                    break;

                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
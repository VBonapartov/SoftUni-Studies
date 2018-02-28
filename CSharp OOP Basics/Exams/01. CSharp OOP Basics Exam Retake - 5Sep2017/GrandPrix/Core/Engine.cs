using System;
using System.Linq;

public class Engine
{
    private IRaceTower race;
    private IReader reader;
    private IWriter writer;

    public Engine(IRaceTower race, IReader reader, IWriter writer)
    {
        this.race = race;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        this.ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        int numberOfLaps = int.Parse(this.reader.ReadLine());
        int trackLength = int.Parse(this.reader.ReadLine());

        race.SetTrackInfo(numberOfLaps, trackLength);

        while (true)
        {
            string[] cmdArgs = this.reader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            switch (command)
            {
                case "RegisterDriver":
                    race.RegisterDriver(cmdArgs.Skip(1).ToList());
                    break;

                case "CompleteLaps":
                    string result = race.CompleteLaps(cmdArgs.Skip(1).ToList());
                    if (!result.Equals(string.Empty))
                    {
                        Console.WriteLine(result);
                    }
                    break;

                case "Box":
                    race.DriverBoxes(cmdArgs.Skip(1).ToList());
                    break;

                case "ChangeWeather":
                    race.ChangeWeather(cmdArgs.Skip(1).ToList());
                    break;

                case "Leaderboard":
                    this.writer.WriteLine(race.GetLeaderboard());
                    break;
            }

            if (this.race.IsRaceFinished)
            {
                this.writer.WriteLine($"{this.race.Winner.Name} wins the race for {this.race.Winner.TotalTime:F3} seconds.");
                break;
            }
        }
    }
}
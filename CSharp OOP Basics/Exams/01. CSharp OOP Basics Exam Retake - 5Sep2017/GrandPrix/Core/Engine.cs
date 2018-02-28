using System;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private RaceTower race;

    public Engine(RaceTower race, IReader reader, IWriter writer)
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

        this.race.SetTrackInfo(numberOfLaps, trackLength);

        while (true)
        {
            string[] cmdArgs = this.reader.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            switch (command)
            {
                case "RegisterDriver":
                    this.race.RegisterDriver(cmdArgs.Skip(1).ToList());
                    break;

                case "CompleteLaps":
                    string result = this.race.CompleteLaps(cmdArgs.Skip(1).ToList());
                    if (!result.Equals(string.Empty))
                    {
                        this.writer.WriteLine(result);
                    }

                    break;

                case "Box":
                    this.race.DriverBoxes(cmdArgs.Skip(1).ToList());
                    break;

                case "ChangeWeather":
                    this.race.ChangeWeather(cmdArgs.Skip(1).ToList());
                    break;

                case "Leaderboard":
                    this.writer.WriteLine(this.race.GetLeaderboard());
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
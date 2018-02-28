using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const Weather DefaultWeather = Weather.Sunny;

    private IList<Driver> drivers;
    private IList<KeyValuePair<Driver, string>> driversNotRacing;

    private Weather weather;

    private int lapsNumber;
    private int lapsLeft;
    private int trackLength;

    public RaceTower()
    {
        this.weather = DefaultWeather;
        this.drivers = new List<Driver>();
        this.driversNotRacing = new List<KeyValuePair<Driver, string>>();
    }

    public Driver Winner { get; private set; }

    public bool IsRaceFinished { get; private set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
        this.lapsLeft = lapsNumber;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            if (commandArgs.Count < 6 || commandArgs.Count > 7)
            {
                return;
            }

            string driverType = commandArgs[0];
            string name = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            double tyreHardness = double.Parse(commandArgs[5]);
            double grip = (commandArgs.Count == 7) ? double.Parse(commandArgs[6]) : 1.0;

            Tyre tyre = TyreFactory.Create(tyreType, tyreHardness, grip);
            Car car = CarFactory.Create(hp, fuelAmount, tyre);
            Driver driver = DriverFactory.Create(driverType, name, car);

            this.drivers.Add(driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];

        Driver driver = this.drivers.FirstOrDefault(d => d.Name.Equals(driversName));

        if (driver == null)
        {
            return;
        }

        driver.TotalTime += 20;

        if (reasonToBox.Equals("ChangeTyres"))
        {
            string tyreType = commandArgs[2];
            double tyreHardness = double.Parse(commandArgs[3]);
            double grip = tyreType.Equals("Ultrasoft") ? double.Parse(commandArgs[4]) : 1;

            Tyre tyre = TyreFactory.Create(tyreType, tyreHardness, grip);
            driver.Car.ChangeTyre(tyre);
        }
        else if (reasonToBox.Equals("Refuel"))
        {
            driver.Car.Refuel(double.Parse(commandArgs[2]));
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder result = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.lapsLeft)
        {
            return $"There is no time! On lap { this.lapsNumber - this.lapsLeft}.";
        }

        while (numberOfLaps > 0)
        {
            this.lapsLeft--;

            foreach (Driver driver in this.drivers)
            {
                try
                {
                    double totalTime = 60.0 / (this.trackLength / driver.Speed);
                    driver.TotalTime += totalTime;

                    driver.ReduceFuelAmount(this.trackLength);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (ArgumentException ioe)
                {
                    this.driversNotRacing.Add(new KeyValuePair<Driver, string>(driver, ioe.Message));
                }
            }

            foreach (KeyValuePair<Driver, string> driverInfo in this.driversNotRacing)
            {
                this.drivers.Remove(driverInfo.Key);
            }

            this.CheckForOvertaking(result);
            numberOfLaps--;
        }

        if (this.lapsLeft == 0)
        {
            this.IsRaceFinished = true;
            this.Winner = this.drivers.OrderBy(d => d.TotalTime).FirstOrDefault();
        }

        return result.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {this.lapsNumber - this.lapsLeft}/{this.lapsNumber}");

        int positionNumber = 1;
        foreach (Driver driver in this.drivers.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{positionNumber++} {driver.Name} {driver.TotalTime:F3}");
        }

        for (int i = this.driversNotRacing.Count - 1; i >= 0; i--)
        {
            sb.AppendLine($"{positionNumber++} {driversNotRacing[i].Key.Name} {driversNotRacing[i].Value}");
        }

        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = (Weather)Enum.Parse(typeof(Weather), commandArgs[0]);
    }

    private void CheckForOvertaking(StringBuilder result)
    {
        List<Driver> currentStandings = this.drivers.OrderByDescending(d => d.TotalTime).ToList();

        for (int i = 0; i < currentStandings.Count - 1; i++)
        {
            Driver firstDriver = currentStandings[i];
            Driver secondDriver = currentStandings[i + 1];

            double difference = Math.Abs(firstDriver.TotalTime - secondDriver.TotalTime);
            int intervalToOvertake = 2;

            bool isCrash = this.CheckConditions(firstDriver, ref intervalToOvertake);

            if (difference <= intervalToOvertake)
            {
                if (isCrash)
                {
                    this.driversNotRacing.Add(new KeyValuePair<Driver, string>(currentStandings[i], "Crashed"));
                    this.drivers.Remove(currentStandings[i]);
                    continue;
                }

                firstDriver.TotalTime -= intervalToOvertake;
                secondDriver.TotalTime += intervalToOvertake;
                result.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.lapsNumber - this.lapsLeft}.");
            }
        }
    }

    private bool CheckConditions(Driver firstDriver, ref int intervalToOvertake)
    {
        if (firstDriver.GetType().Name.Equals("AggressiveDriver")
            && firstDriver.Car.Tyre.GetType().Name.Equals("UltrasoftTyre"))
        {
            intervalToOvertake = 3;
            if (this.weather.Equals(Weather.Foggy))
            {
                return true;
            }
        }

        if (firstDriver.GetType().Name.Equals("EnduranceDriver")
            && firstDriver.Car.Tyre.GetType().Name.Equals("HardTyre"))
        {
            intervalToOvertake = 3;
            if (this.weather.Equals(Weather.Rainy))
            {
                return true;
            }
        }

        return false;
    }
}
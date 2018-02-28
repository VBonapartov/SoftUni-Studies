using System;

public static class DriverFactory
{
    public static IDriver Create(string driverType, string name, ICar car)
    {
        switch (driverType)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);

            case "Endurance":
                return new EnduranceDriver(name, car);

            default:
                throw new ArgumentException();
        }
    }
}

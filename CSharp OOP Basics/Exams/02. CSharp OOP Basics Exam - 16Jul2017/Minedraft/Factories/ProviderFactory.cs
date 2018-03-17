using System;
using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Create(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        switch (type)
        {
            case "Pressure":
                return new PressureProvider(id, energyOutput);

            case "Solar":
                return new SolarProvider(id, energyOutput);

            default:
                throw new ArgumentException();
        }
    }
}

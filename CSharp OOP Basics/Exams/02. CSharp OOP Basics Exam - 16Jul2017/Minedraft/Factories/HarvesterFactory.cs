using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Create(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);        

        switch (type)
        {
            case "Sonic":
                int sonicFactor = int.Parse(arguments[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);

            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);

            default:
                throw new ArgumentException();
        }
    }
}

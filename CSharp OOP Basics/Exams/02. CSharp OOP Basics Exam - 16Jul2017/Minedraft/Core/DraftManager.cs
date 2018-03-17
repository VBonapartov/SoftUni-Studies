using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private const SystemMode DefaultSystemMode = SystemMode.Full;

    private List<Harvester> harvesters;
    private List<Provider> providers;

    private SystemMode systemMode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        this.systemMode = DefaultSystemMode;
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;

        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.Create(arguments);
            this.harvesters.Add(harvester);

            return $"Successfully registered {harvester.GetTypeName()} - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = ProviderFactory.Create(arguments);
            this.providers.Add(provider);

            return $"Successfully registered {provider.GetTypeName()} - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double energyRequirementModifier = this.systemMode.Equals(SystemMode.Full) 
                                           ? 1.0 : this.systemMode.Equals(SystemMode.Half) 
                                                   ? 0.6 : 0.0;

        double oreOutputModifier = this.systemMode.Equals(SystemMode.Full)
                                   ? 1.0 : this.systemMode.Equals(SystemMode.Half)
                                           ? 0.5 : 0.0;

        double energyProvided = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += energyProvided;

        double totalEnergyRequired = this.harvesters.Sum(h => h.EnergyRequirement * energyRequirementModifier);

        double plumbusOreMined = 0;

        if (this.totalStoredEnergy >= totalEnergyRequired)
        {
            plumbusOreMined = this.harvesters.Sum(h => h.OreOutput * oreOutputModifier);
            this.totalStoredEnergy -= totalEnergyRequired;
            this.totalMinedOre += plumbusOreMined;
        }

        StringBuilder result = new StringBuilder();

        result.AppendLine("A day has passed.");
        result.AppendLine($"Energy Provided: {energyProvided}");
        result.AppendLine($"Plumbus Ore Mined: {plumbusOreMined}");

        return result.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        if (Enum.TryParse(arguments[0], out SystemMode mode))
        {
            if (mode.Equals(SystemMode.Full) || mode.Equals(SystemMode.Half) || mode.Equals(SystemMode.Energy))
            {
                this.systemMode = mode;
            }
        }

        return $"Successfully changed working mode to {this.systemMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        Participant participant = (Participant)this.providers.FirstOrDefault(p => p.Id.Equals(id)) ?? 
                                               this.harvesters.FirstOrDefault(p => p.Id.Equals(id));

        return (participant != null) 
               ? participant.ToString() 
               : $"No element found with id - {id}";    
    }

    public string ShutDown()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine("System Shutdown");
        result.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        result.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return result.ToString();
    }
}

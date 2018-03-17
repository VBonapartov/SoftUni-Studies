using System;
using System.Text;

public abstract class Harvester : Participant
{
    private const int MinEnergyRequirement = 0;
    private const int MaxEnergyRequirement = 20000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }

        protected set
        {
            if (value < MinEnergyRequirement || value > MaxEnergyRequirement)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string GetTypeName()
    {
        string type = this.GetType().Name;
        int endIndex = type.IndexOf("Harvester");
        type = type.Insert(endIndex, " ");

        return type;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result
            .AppendLine($"{this.GetTypeName()} - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return result.ToString().Trim();
    }
}
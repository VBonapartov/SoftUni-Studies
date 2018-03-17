using System;
using System.Text;

public abstract class Provider : Participant
{
    private const int MinEnergyOutput = 0;
    private const int MaxEnergyOutput = 10000;

    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }

        protected set
        {
            if (value < MinEnergyOutput || value >= MaxEnergyOutput)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string GetTypeName()
    {
        string type = this.GetType().Name;
        int endIndex = type.IndexOf("Provider");
        type = type.Insert(endIndex, " ");

        return type;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result
            .AppendLine($"{this.GetTypeName()} - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        return result.ToString().Trim();
    }
}

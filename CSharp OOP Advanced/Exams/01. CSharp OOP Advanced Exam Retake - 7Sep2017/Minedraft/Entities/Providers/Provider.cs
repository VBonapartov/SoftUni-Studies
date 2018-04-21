using System.Text;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const double DurabilityDailyLoss = 100;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityDailyLoss;

        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(string.Format(Constants.EntityFound, this.GetType().Name));
        result.AppendLine(string.Format(Constants.EntityDurability, this.Durability));

        return result.ToString().Trim();
    }
}
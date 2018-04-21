using System.Text;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const double DurabilityModeLoss = 100;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; }

    public double EnergyRequirement { get; }

    public virtual double Durability { get; protected set; }

    public virtual void Broke()
    {
        this.Durability -= DurabilityModeLoss;

        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(string.Format(Constants.EntityFound, this.GetType().Name));
        result.AppendLine(string.Format(Constants.EntityDurability, this.Durability));

        return result.ToString().Trim();
    }
}
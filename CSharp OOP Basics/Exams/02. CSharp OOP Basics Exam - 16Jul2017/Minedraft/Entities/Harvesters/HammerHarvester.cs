public class HammerHarvester : Harvester
{
    private const int OreOutputIncreasePercent = 200;
    private const int EnergyRequirementIncreasePercent = 100;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= 1 + (OreOutputIncreasePercent / 100.0);
        this.EnergyRequirement *= 1 + (EnergyRequirementIncreasePercent / 100.0);
    }
}

public class PressureProvider : Provider
{
    private const int EnergyOutputIncreasePercent = 50;

    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput += this.EnergyOutput * (EnergyOutputIncreasePercent / 100.0);
    }
}

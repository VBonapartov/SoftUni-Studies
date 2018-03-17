public class LightSoftware : Software
{
    private const double CapacityConsumptionIncreaseMultiplier = 0.5;
    private const double MemoryConsumptionDecreaseMultiplier = 0.5;

    public LightSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, capacityConsumption, memoryConsumption)
    {
        this.IncreaseCapacityConsumption();
        this.DecreaseMemoryConsumption();
    }

    private void IncreaseCapacityConsumption()
    {
        this.CapacityConsumption += (int)(this.CapacityConsumption * CapacityConsumptionIncreaseMultiplier);
    }

    private void DecreaseMemoryConsumption()
    {
        this.MemoryConsumption -= (int)(this.MemoryConsumption * MemoryConsumptionDecreaseMultiplier);
    }
}

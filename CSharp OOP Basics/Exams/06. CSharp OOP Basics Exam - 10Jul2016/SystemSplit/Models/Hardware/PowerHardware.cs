public class PowerHardware : Hardware
{
    private const double CapacityDecreaseMultiplier = 0.75;
    private const double MemoryIncreaseMultiplier = 0.75;

    public PowerHardware(string name, int maxCapacity, int maxMemory)
        : base(name, maxCapacity, maxMemory)
    {
        this.DecreaseCapacity();
        this.IncreaseMemory();
    }

    private void DecreaseCapacity()
    {
        this.MaxCapacity -= (int)(this.MaxCapacity * CapacityDecreaseMultiplier);
    }

    private void IncreaseMemory()
    {
        this.MaxMemory += (int)(this.MaxMemory * MemoryIncreaseMultiplier);
    }
}

public class HeavyHardware : Hardware
{
    private const double MemoryDecreaseMultiplier = 0.25;
    private const int CapacityIncreaseMultiplier = 2;

    public HeavyHardware(string name, int maxCapacity, int maxMemory)
        : base(name, maxCapacity, maxMemory)
    {
        this.DecreaseMemory();
        this.IncreaseCapacity();
    }

    private void DecreaseMemory()
    {
        this.MaxMemory -= (int)(this.MaxMemory * MemoryDecreaseMultiplier);
    }

    private void IncreaseCapacity()
    {
        this.MaxCapacity *= CapacityIncreaseMultiplier;
    }
}

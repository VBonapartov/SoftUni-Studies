public class ExpressSoftware : Software
{
    private const int MemoryConsumptionIncreaseMultiplier = 2;

    public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption)
        : base(name, capacityConsumption, memoryConsumption)
    {
        this.IncreaseMemoryConsumption();
    }

    private void IncreaseMemoryConsumption()
    {
        this.MemoryConsumption *= MemoryConsumptionIncreaseMultiplier;
    }
}

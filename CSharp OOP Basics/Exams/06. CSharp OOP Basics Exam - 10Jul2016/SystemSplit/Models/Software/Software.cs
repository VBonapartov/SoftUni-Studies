public abstract class Software
{
    private string name;
    private int capacityConsumption;
    private int memoryConsumption;

    protected Software(string name, int capacityConsumption, int memoryConsumption)
    {
        this.Name = name;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }

    public string Name
    {
        get => this.name;
        private set { this.name = value; }
    }

    public int CapacityConsumption
    {
        get => this.capacityConsumption;
        protected set { this.capacityConsumption = value; }
    }

    public int MemoryConsumption
    {
        get => this.memoryConsumption;
        protected set { this.memoryConsumption = value; }
    }
}

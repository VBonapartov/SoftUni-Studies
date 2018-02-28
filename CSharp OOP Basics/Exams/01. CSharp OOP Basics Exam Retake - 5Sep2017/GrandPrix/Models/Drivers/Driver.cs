public abstract class Driver : IDriver
{
    private string name;
    private double totalTime;
    private ICar car;
    private double fuelConsumptionPerKm;

    public Driver(string name, ICar car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public double TotalTime
    {
        get => this.totalTime;
        set => this.totalTime = value;
    }

    public ICar Car
    {
        get => this.car;
        private set => this.car = value;
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        protected set => this.fuelConsumptionPerKm = value;
    }

    public virtual double Speed => (this.Car.HorsePower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public virtual void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }
}
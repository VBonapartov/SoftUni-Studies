public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    protected double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }

        set
        {
            this.fuelQuantity = value;
        }
    }

    protected double FuelConsumptionPerKm
    {
        get
        {
            return this.fuelConsumptionPerKm;
        }

        private set
        {
            this.fuelConsumptionPerKm = value;
        }
    }

    public virtual void Refuel(double fuel) => this.FuelQuantity += fuel;
        
    public string TryTravelDistance(double distance)
    {
        if (this.Drive(distance))
        {
            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
    
    protected abstract bool Drive(double distance);
}
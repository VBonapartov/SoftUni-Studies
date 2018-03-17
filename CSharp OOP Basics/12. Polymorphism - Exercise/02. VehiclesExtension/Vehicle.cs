using System;

public abstract class Vehicle
{    
    protected const string FuelNegativeQuantityMessage = "Fuel must be a positive number";
    protected const string FuelBiggerQuantityThanCapacityMessage = "Cannot fit {0} fuel in the tank";
    private const double DefaultRefueledPercent = 1;

    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;        
    }

    protected virtual double RefueledPercent => DefaultRefueledPercent;

    protected virtual double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.fuelQuantity = (value > this.TankCapacity) ? 0 : value;            
        }
    }

    protected double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        private set { this.fuelConsumptionPerKm = value; }
    }

    protected double TankCapacity
    {
        get => this.tankCapacity;
        private set { this.tankCapacity = value; }
    }

    public void Refuel(double fuel)
    {
        this.ValidateFuelQuantity(fuel, RefueledPercent);
        this.FuelQuantity += fuel * RefueledPercent;
    }
      
    public string TryTravelDistance(double distance, bool isAirConditionerTurnedOn = true)
    {
        if (this.Drive(distance, isAirConditionerTurnedOn))
        {
            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }

    protected void ValidateFuelQuantity(double fuel, double refueled)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException(FuelNegativeQuantityMessage);
        }

        if (fuel * refueled > this.TankCapacity)
        {
            throw new ArgumentException(string.Format(FuelBiggerQuantityThanCapacityMessage, fuel));
        }
    }

    protected abstract bool Drive(double distance, bool isAirConditionerTurnedOn);
}
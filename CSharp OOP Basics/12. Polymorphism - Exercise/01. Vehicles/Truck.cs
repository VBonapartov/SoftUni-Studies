public class Truck : Vehicle
{
    private const double TruckAirCondConsumption = 1.6;
    private const double FuelLossFactor = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override void Refuel(double fuel)
    {
        this.FuelQuantity += fuel * FuelLossFactor;
    }

    protected override bool Drive(double distance)
    {
        double neededFuel = (this.FuelConsumptionPerKm + TruckAirCondConsumption) * distance;

        if (neededFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= neededFuel;
        return true;
    }
}
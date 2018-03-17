public class Car : Vehicle
{
    private const double CarAirCondConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm)
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    protected override bool Drive(double distance)
    {
        double neededFuel = (this.FuelConsumptionPerKm + CarAirCondConsumption) * distance;

        if (neededFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= neededFuel;
        return true;
    }
}
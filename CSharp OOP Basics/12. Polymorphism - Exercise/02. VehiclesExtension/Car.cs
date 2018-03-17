public class Car : Vehicle
{
    private const double CarAirCondConsumption = 0.9d;

    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    protected override bool Drive(double distance, bool isAirConditionerTurnedOn)
    {
        double extraFuelConsumption = (isAirConditionerTurnedOn) ? CarAirCondConsumption : 0;

        double neededFuel = (this.FuelConsumptionPerKm + extraFuelConsumption) * distance;

        if (neededFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= neededFuel;
        return true;
    }
}
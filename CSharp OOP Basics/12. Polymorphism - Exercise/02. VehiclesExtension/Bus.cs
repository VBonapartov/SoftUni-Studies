public class Bus : Vehicle
{
    private const double BusAirCondConsumption = 1.4d;

    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    protected override bool Drive(double distance, bool isAirConditionerTurnedOn)
    {
        double extraFuelConsumption = isAirConditionerTurnedOn ? BusAirCondConsumption : 0;

        double neededFuel = (this.FuelConsumptionPerKm + extraFuelConsumption) * distance;

        if (neededFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= neededFuel;
        return true;
    }
}
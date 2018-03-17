public class Truck : Vehicle
{
    private const double TruckAirCondConsumption = 1.6d;
    private const double TruckRefueledPercent = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    protected override double RefueledPercent => TruckRefueledPercent;

    protected override bool Drive(double distance, bool isAirConditionerTurnedOn)
    {
        double extraFuelConsumption = isAirConditionerTurnedOn ? TruckAirCondConsumption : 0;

        double neededFuel = (this.FuelConsumptionPerKm + extraFuelConsumption) * distance;

        if (neededFuel > this.FuelQuantity)
        {
            return false;
        }

        this.FuelQuantity -= neededFuel;
        return true;
    }
}
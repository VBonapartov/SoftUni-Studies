public class EnduranceDriver : Driver
{
    private new const double FuelConsumptionPerKm = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car, FuelConsumptionPerKm)
    {
    }
}
public class EnduranceDriver : Driver
{
    private new const double FuelConsumptionPerKm = 1.5;

    public EnduranceDriver(string name, ICar car)
        : base(name, car, FuelConsumptionPerKm)
    {
    }
}
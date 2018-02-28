public class AggressiveDriver : Driver
{
    private new const double FuelConsumptionPerKm = 2.7;

    public AggressiveDriver(string name, ICar car)
        : base(name, car, FuelConsumptionPerKm)
    {
    }

    public override double Speed
    {
        get
        {
            return base.Speed * 1.3;
        }        
    }
}
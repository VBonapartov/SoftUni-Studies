public class AggressiveDriver : Driver
{
    private new const double FuelConsumptionPerKm = 2.7;
    private const double SpeedMultiply = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, FuelConsumptionPerKm)
    {
    }

    public override double Speed
    {
        get
        {
            return base.Speed * SpeedMultiply;
        }        
    }
}
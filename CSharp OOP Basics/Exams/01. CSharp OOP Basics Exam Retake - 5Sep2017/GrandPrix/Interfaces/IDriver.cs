public interface IDriver
{
    string Name { get; }

    ICar Car { get; }

    double FuelConsumptionPerKm { get; }

    void ReduceFuelAmount(int length);

    double Speed { get; }

    double TotalTime { get; set; }
}
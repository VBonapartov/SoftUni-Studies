public interface ICar
{
    int HorsePower { get; }

    ITyre Tyre { get; }

    double FuelAmount { get; }

    void Refuel(double fuel);

    void ReduceFuel(int length, double fuelConsumption);

    void ChangeTyre(ITyre newTyre);
}
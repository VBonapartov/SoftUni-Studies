using System;

public class Car : ICar
{
    private const int FuelTankMaximumCapacity = 160;

    private double fuelAmount;
    private ITyre tyre;

    public Car(int horsePower, double fuelAmount, ITyre tyre)
    {
        this.HorsePower = horsePower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int HorsePower { get; private set; }

    public ITyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = (value > FuelTankMaximumCapacity)
                              ? FuelTankMaximumCapacity
                              : value;
        }
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void ChangeTyre(ITyre newTyre)
    {
        this.Tyre = newTyre;
    }
}
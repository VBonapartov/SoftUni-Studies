using System;

public class Car
{
    private const int FuelTankMaximumCapacity = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int horsePower, double fuelAmount, Tyre tyre)
    {
        this.Hp = horsePower;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public Tyre Tyre
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

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}
using System.Collections.Generic;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        this.ParkedCars = new List<Car>();
    }

    private List<Car> ParkedCars
    {
        get => this.parkedCars;
        set { this.parkedCars = value; }
    }

    public void Park(Car car)
    {
        this.ParkedCars.Add(car);
    }

    public void Unpark(Car car)
    {
        this.ParkedCars.Remove(car);
    }

    public bool IsCarParked(Car car)
    {
        return this.ParkedCars.Contains(car);
    }

    public void TuneCars(int tuneIndex, string addOn)
    {
        foreach (Car car in this.ParkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }
}

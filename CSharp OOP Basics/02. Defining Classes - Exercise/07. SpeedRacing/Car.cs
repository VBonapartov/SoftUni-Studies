public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distanceTraveled;

    public string Model
    {
        get { return this.model; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
    }

    public double DistanceTraveled
    {
        get { return this.distanceTraveled; }
        set { this.distanceTraveled = value; }
    }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.distanceTraveled = 0.0d;
    }

    public bool MoveCar(double amountOfKm)
    {
        double fuelNeeded = this.fuelConsumption * amountOfKm;
        if (fuelNeeded <= this.FuelAmount)
        {
            this.FuelAmount -= fuelNeeded;
            this.DistanceTraveled += amountOfKm;

            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTraveled}";
    }
}
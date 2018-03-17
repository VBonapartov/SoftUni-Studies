public class Cargo
{
    private int cargoWeight;
    private string cargoType;

    public Cargo(int cargoWeight, string cargoType)
    {
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
    }

    public int CargoWeight
    {
        get { return this.cargoWeight; }
    }

    public string CargoType
    {
        get { return this.cargoType; }
    }
}
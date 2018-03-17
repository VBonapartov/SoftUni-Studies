public class Car
{
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public string Model
    {
        get { return this.model; }
    }

    public int Speed
    {
        get { return this.speed; }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}
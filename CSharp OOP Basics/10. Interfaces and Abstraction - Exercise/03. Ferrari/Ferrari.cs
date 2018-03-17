public class Ferrari : ICar
{
    private string driver;

    public Ferrari(string driver, string model)
    {
        this.Driver = driver;
        this.Model = model;
    }

    public string Driver
    {
        get { return this.driver; }
        private set { this.driver = value; }
    }

    public string Model
    {
        get;
        private set;
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
    }
}
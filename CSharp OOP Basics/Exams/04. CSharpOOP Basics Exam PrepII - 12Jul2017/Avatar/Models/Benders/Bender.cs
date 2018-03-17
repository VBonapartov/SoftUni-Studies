public abstract class Bender : IBender
{
    private string name;
    private int power;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name
    {
        get => this.name;
        private set { this.name = value; }
    }

    public int Power
    {
        get => this.power;
        private set { this.power = value; }
    }

    public string GetNationType()
    {
        string type = this.GetType().Name;
        int endIndex = type.IndexOf("Bender");
        type = type.Substring(0, endIndex);

        return type;
    }

    public abstract double CalculateTotalPower();

    public override string ToString()
    {
        string result = $"###{this.GetNationType()} Bender: {this.Name}, Power: {this.Power}, ";
        return result;
    }
}

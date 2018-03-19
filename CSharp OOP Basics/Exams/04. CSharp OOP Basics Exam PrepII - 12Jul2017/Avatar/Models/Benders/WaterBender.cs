public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    private double WaterClarity
    {
        get => this.waterClarity;
        set { this.waterClarity = value; }
    }

    public override double CalculateTotalPower()
    {
        return this.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        string result = base.ToString() + $"Water Clarity: {this.WaterClarity:F2}";
        return result;
    }
}

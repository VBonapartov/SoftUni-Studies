public class FireBender : Bender
{
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    private double HeatAggression
    {
        get => this.heatAggression;
        set { this.heatAggression = value; }
    }

    public override double CalculateTotalPower()
    {
        return this.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        string result = base.ToString() + $"Heat Aggression: {this.HeatAggression:F2}";
        return result;
    }
}

public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    private double GroundSaturation
    {
        get => this.groundSaturation;
        set { this.groundSaturation = value; }
    }

    public override double CalculateTotalPower()
    {
        return this.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        string result = base.ToString() + $"Ground Saturation: {this.GroundSaturation:F2}";
        return result;
    }
}

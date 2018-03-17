public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity)
            : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    private double AerialIntegrity
    {
        get => this.aerialIntegrity;
        set { this.aerialIntegrity = value; }
    }

    public override double CalculateTotalPower()
    {
        return this.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        string result = base.ToString() + $"Aerial Integrity: {this.AerialIntegrity:F2}";
        return result;
    }
}

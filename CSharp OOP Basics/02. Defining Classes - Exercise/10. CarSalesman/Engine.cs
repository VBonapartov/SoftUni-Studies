using System;
using System.Text;

public class Engine
{
    private string model;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string model, int power, int displacement = -1, string efficiency = "n/a")
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement)
        : this(model, power)
    {
        this.displacement = displacement;
    }

    public Engine(string model, int power, string efficiency)
        : this(model, power)
    {
        this.efficiency = efficiency;
    }

    public string Model
    {
        get { return this.model; }
    }

    public int Power
    {
        get { return this.power; }
    }

    public int Displacement
    {
        get { return this.displacement; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"  {this.Model}:" + Environment.NewLine);
        sb.Append($"    Power: {this.Power}" + Environment.NewLine);
        sb.AppendFormat("    Displacement: {0}" + Environment.NewLine, (this.Displacement == -1) ? "n/a" : this.Displacement.ToString());
        sb.Append($"    Efficiency: {this.Efficiency}" + Environment.NewLine);

        return sb.ToString();
    }
}
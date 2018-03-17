using System;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public Car(string model, Engine engine, int weight = -1, string color = "n/a")
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        this.weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        this.color = color;
    }

    public string Model
    {
        get { return this.model; }
    }

    public Engine Engine
    {
        get { return this.engine; }
    }

    public int Weight
    {
        get { return this.weight; }
    }

    public string Color
    {
        get { return this.color; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{this.Model}:" + Environment.NewLine);
        sb.Append(this.Engine.ToString());
        sb.AppendFormat("  Weight: {0}" + Environment.NewLine, (this.Weight == -1) ? "n/a" : this.Weight.ToString());
        sb.Append($"  Color: {this.Color}");

        return sb.ToString();
    }
}
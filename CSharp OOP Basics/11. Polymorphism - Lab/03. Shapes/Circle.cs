using System;

public class Circle : Shape
{
    private const string CircleInvalidRadiusMessage = "Circle cannot have a zero or negative radius!";

    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    private double Radius
    {
        get
        {
            return this.radius;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Radius), CircleInvalidRadiusMessage);
            }

            this.radius = value;
        }
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(this.Radius, 2);
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}
using System;

public class Rectangle : Shape
{
    private const string RectangleInvalidHeightMessage = "Height must be non-zero and positive!";
    private const string RectangleInvalidWidthMessage = "Width must be non-zero and positive!";

    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    private double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Height), RectangleInvalidHeightMessage);
            }

            this.height = value;
        }
    }

    private double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Width), RectangleInvalidWidthMessage);
            }

            this.width = value;
        }
    }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Height + this.Width);
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
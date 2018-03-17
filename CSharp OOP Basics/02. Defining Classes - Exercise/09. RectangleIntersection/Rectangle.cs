using System;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double coordinateX;
    private double coordinateY;

    public Rectangle(string id, double width, double height, double coordinateX, double coordinateY)
    {
        this.id = id;
        this.width = Math.Abs(width);
        this.height = Math.Abs(height);
        this.coordinateX = coordinateX;
        this.coordinateY = coordinateY;
    }

    public string ID
    {
        get { return this.id; }
    }

    public double Width
    {
        get { return this.width; }
    }

    public double Height
    {
        get { return this.width; }
    }

    public double CoordinateX
    {
        get { return this.coordinateX; }
    }

    public double CoordinateY
    {
        get { return this.coordinateY; }
    }

    public bool CheckForIntersection(Rectangle rect)
    {
        return rect.CoordinateX + rect.width >= this.CoordinateX &&
               rect.CoordinateX <= this.CoordinateX + this.width &&
               rect.CoordinateY >= this.CoordinateY - this.height &&
               rect.CoordinateY - rect.height <= this.CoordinateY;
    }
}
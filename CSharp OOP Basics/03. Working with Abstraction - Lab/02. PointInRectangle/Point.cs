using System;
using System.Linq;

public class Point
{
    public Point(double x, double y)
    {
        this.CoordinateX = x;
        this.CoordinateY = y;
    }

    public Point(Func<string> readPoint)
    {
        double[] pointCoords = readPoint().Split(" ").Select(double.Parse).ToArray();

        this.CoordinateX = pointCoords[0];
        this.CoordinateY = pointCoords[1];
    }

    public double CoordinateX { get; private set; }

    public double CoordinateY { get; private set; }
}
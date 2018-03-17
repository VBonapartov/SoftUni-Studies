using System.Linq;

public class Rectangle
{
    private Point topLeft;
    private Point bottomRight;

    public Rectangle(string coords)
    {
        double[] coordinates = coords.Split(" ").Select(double.Parse).ToArray();

        this.topLeft = new Point(coordinates[0], coordinates[1]);
        this.bottomRight = new Point(coordinates[2], coordinates[3]);
    }

    public bool Contains(Point point)
    {
        return point.CoordinateX >= this.topLeft.CoordinateX &&
                point.CoordinateX <= this.bottomRight.CoordinateX &&
                point.CoordinateY >= this.topLeft.CoordinateY &&
                point.CoordinateY <= this.bottomRight.CoordinateY;
    }
}
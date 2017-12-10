import java.util.Arrays;
import java.util.Scanner;

public class IntersectionOfCircles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Circle c1 = ReadCircle(scanner);
        Circle c2 = ReadCircle(scanner);

        boolean isIntersect = Intersect(c1, c2);
        System.out.printf("%s", (isIntersect) ? "Yes" : "No");
    }

    private static Circle ReadCircle(Scanner scanner) {
        int[] input = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();

        Circle c = new Circle();
        c.setCenter(input[0], input[1]);
        c.setRadius(input[2]);

        return c;
    }

    private static boolean Intersect(Circle c1, Circle c2) {
        double distnace = CalculateDistance(c1.getCenter(), c2.getCenter());
        return distnace <= c1.getRadius() + c2.getRadius();
    }

    private static double CalculateDistance(Point p1, Point p2) {
        return Math.sqrt(Math.pow(p1.getX() - p2.getX(), 2) + Math.pow(p1.getY() - p2.getY(), 2));
    }
}

class Point
{
    private int X;
    private int Y;

    public void setX (int x) {
        this.X = x;
    }

    public void setY (int y) {
        this.Y = y;
    }

    public int getX () {
        return this.X;
    }

    public int getY () {
        return this.Y;
    }
}

class Circle
{
    private Point Center = new Point();
    private int Radius;

    public void setCenter (int x, int y) {
        this.Center.setX(x);
        this.Center.setY(y);
    }

    public Point getCenter () {
        return this.Center;
    }

    public void setRadius (int radius) {
        this.Radius = radius;
    }

    public int getRadius () {
        return this.Radius;
    }
}

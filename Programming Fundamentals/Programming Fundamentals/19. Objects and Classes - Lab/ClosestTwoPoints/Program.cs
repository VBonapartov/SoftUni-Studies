using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestTwoPoints
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = ReadPoints();
            List<Point> closestPoints = FindClosestPoints(points);

            PrintDistance(closestPoints);
            PrintPoint(closestPoints[0]);
            PrintPoint(closestPoints[1]);
        }

        static private List<Point> ReadPoints()
        {
            int count = int.Parse(Console.ReadLine());

            List<Point> points = new List<Point>();
            for(int i = 0; i < count; i++)
            {                
                points.Add(ReadPoint());
            }

            return points;
        }

        static private Point ReadPoint()
        {
            int[] point = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point p = new Point()
            {
                X = point[0],
                Y = point[1]
            };

            return p;
        }

        static private List<Point> FindClosestPoints(List<Point> points)
        {
            double minDistance = double.MaxValue;

            List<Point> closestTwoPoints = null;
            for(int i = 0; i < points.Count; i++)
                for(int p = i + 1; p < points.Count; p++)
                {
                    double distance = CalculateDistance(points[i], points[p]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTwoPoints = new List<Point> { points[i], points[p] };
                    }
                }

            return closestTwoPoints;
        }

        static private void PrintDistance(List<Point> p)
        {
            double distance = CalculateDistance(p[0], p[1]);
            Console.WriteLine($"{distance:F3}");
        }

        static private void PrintPoint(Point p)
        {
            Console.WriteLine($"({p.X}, {p.Y})");
        }

        static private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}

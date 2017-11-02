using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfCircles
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = ReadCircle();
            Circle c2 = ReadCircle();

            bool isIntersect = Intersect(c1, c2);
            Console.WriteLine((isIntersect) ? "Yes" : "No");
        }

        static private Circle ReadCircle()
        {
            string[] input = Console.ReadLine().Trim().Split(' ');

            Circle c = new Circle();
            c.Center = new Point
            {
                X = int.Parse(input[0]),
                Y = int.Parse(input[1])
            };
            c.Radius = int.Parse(input[2]);

            return c;
        }
        
        static private bool Intersect(Circle c1, Circle c2)
        {
            double distnace = CalculateDistance(c1.Center, c2.Center);
            return distnace <= c1.Radius + c2.Radius;
        }

        static private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}

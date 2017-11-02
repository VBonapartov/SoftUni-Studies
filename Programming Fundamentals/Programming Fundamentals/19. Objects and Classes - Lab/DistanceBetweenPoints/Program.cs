using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenPoints
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
            Point p1 = ReadPoint();
            Point p2 = ReadPoint();

            double distance = CalculateDistance(p1, p2);
            Console.WriteLine($"{distance:F3}");
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

        static private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }


}

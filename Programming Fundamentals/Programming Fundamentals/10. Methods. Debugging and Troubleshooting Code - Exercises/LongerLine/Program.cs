using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double line1Length = GetLineLength(x1, y1, x2, y2);
            double line2Length = GetLineLength(x3, y3, x4, y4);

            if(line1Length >= line2Length)
            {
                (double resX1, double resY1, double resX2, double resY2) = GetClosestPointToTheCenter(x1, y1, x2, y2);
                Console.WriteLine($"({resX1}, {resY1})({resX2}, {resY2})");
            }
            else
            {
                (double resX1, double resY1, double resX2, double resY2) = GetClosestPointToTheCenter(x3, y3, x4, y4);
                Console.WriteLine($"({resX1}, {resY1})({resX2}, {resY2})");
            }
        }

        static private double GetLineLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        static private (double x1, double y1, double x2, double y2) GetClosestPointToTheCenter(double x1, double y1, double x2, double y2)
        {
            double firstPointDist = CalculateDistance(x1, y1);
            double secondPointDist = CalculateDistance(x2, y2);

            if (firstPointDist <= secondPointDist)
            {
                return (x1, y1, x2, y2);
            }
            else
            {
                return (x2, y2, x1, y1);
            }
        }

        public static double CalculateDistance(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }
    }
}

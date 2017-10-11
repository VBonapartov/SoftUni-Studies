using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            (double x, double y) = GetClosestPointToTheCenter(x1, y1, x2, y2);
            Console.WriteLine($"({x}, {y})");
        }

        static private (double x, double y) GetClosestPointToTheCenter(double x1, double y1, double x2, double y2)
        {
            double firstPointDist = CalculateDistance(x1, y1);
            double secondPointDist = CalculateDistance(x2, y2);

            if(firstPointDist <= secondPointDist)
            {
                return (x1, y1);
            }
            else
            {
                return (x2, y2);
            }            
        }

        public static double CalculateDistance(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }
    }
}

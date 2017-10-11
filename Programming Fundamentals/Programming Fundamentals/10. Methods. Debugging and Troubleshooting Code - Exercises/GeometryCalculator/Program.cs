using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();

            double result = 0.00d;
            switch (figureType)
            {
                case "triangle":
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleHeight = double.Parse(Console.ReadLine());
                    result = (triangleSide * triangleHeight) / 2.00d;
                    break;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    result = Math.Pow(squareSide, 2);
                    break;
                case "rectangle":
                    double rectangleWidth = double.Parse(Console.ReadLine());
                    double rectangleHeight = double.Parse(Console.ReadLine());
                    result = rectangleWidth * rectangleHeight;
                    break;
                case "circle":
                    double circleRadius = double.Parse(Console.ReadLine());
                    result = Math.PI * Math.Pow(circleRadius, 2);
                    break;
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}

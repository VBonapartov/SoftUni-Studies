using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePerimeter_12Digits_
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double circleArea = 2 * Math.PI * radius;
            Console.WriteLine($"{circleArea:F12}");
        }
    }
}

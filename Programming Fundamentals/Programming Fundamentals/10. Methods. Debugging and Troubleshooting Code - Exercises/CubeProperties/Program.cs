using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideOfTheCube = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            double result = 0.00d;
            switch(parameter)
            {
                case "face":
                    result = Math.Sqrt(2 * Math.Pow(sideOfTheCube, 2));
                    break;
                case "space":
                    result = Math.Sqrt(3 * Math.Pow(sideOfTheCube, 2));
                    break;
                case "volume":
                    result = Math.Pow(sideOfTheCube, 3);
                    break;
                case "area":
                    result = 6 * Math.Pow(sideOfTheCube, 2);
                    break;
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}

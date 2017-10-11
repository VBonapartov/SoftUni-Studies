using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = RaiseToPower(number, power);

            Console.WriteLine(result);
        }

        static private double RaiseToPower(double number, int power)
        {
            double result = 0.00d;
            result = Math.Pow(number, power);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double exp = 0.000001;
            double diff = Math.Abs(a - b);

            bool isEqual = (diff < exp);
            Console.WriteLine(isEqual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromTerabytesToBits
{
    class Program
    {
        static void Main(string[] args)
        {
            double terabytes = double.Parse(Console.ReadLine());

            decimal fromTerabytesToBits = (decimal)terabytes * (1024m * 1024m * 1024m * 1024m * 8m);
            Console.WriteLine($"{fromTerabytesToBits:F0}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double megapixels = (width * height) / 1000000.00;
            Console.WriteLine($"{width}x{height} => {Math.Round(megapixels, 1)}MP");
        }
    }
}

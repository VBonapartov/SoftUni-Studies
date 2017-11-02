using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToList();

            numbers = numbers.OrderByDescending(x => x).Take(3).ToList();
            Console.WriteLine($"{string.Join(" ", numbers)}");
        }
    }
}

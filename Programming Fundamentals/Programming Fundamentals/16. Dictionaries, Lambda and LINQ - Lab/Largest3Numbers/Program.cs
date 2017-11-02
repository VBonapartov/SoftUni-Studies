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
            List<double> nums = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToList();

            List<double> result = nums.OrderByDescending(x => x).Take(3).ToList();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}

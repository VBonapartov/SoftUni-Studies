using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> listNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            listNumbers.Sort();
            Console.WriteLine(string.Join(" <= ",listNumbers));
        }
    }
}

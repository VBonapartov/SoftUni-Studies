using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            double average = intArr.Average();
            List <int> result = intArr.Where(i => i > average).OrderByDescending(i => i).ToList();

            if(result.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if(result.Count < 5)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(string.Join(" ", result.Take(5)));
            }
        }
    }
}

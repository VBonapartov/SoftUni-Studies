using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            nums = nums.Where(x => x % 2 == 0).ToList();            
            double average = nums.Average();

            nums = nums.Select(x => { if (x > average) return x + 1; else return x - 1; }).ToList();
            Console.WriteLine($"{string.Join(" ", nums)}");
        }
    }
}

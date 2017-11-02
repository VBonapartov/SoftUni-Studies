using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMinMaxAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for(int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = numbers.Sum();
            int min = numbers.Min();
            int max = numbers.Max();
            double average = numbers.Average();

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Average = {average}");
        }
    }
}

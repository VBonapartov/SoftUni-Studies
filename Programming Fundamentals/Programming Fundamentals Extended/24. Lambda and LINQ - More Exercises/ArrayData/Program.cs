using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            numbers = numbers.Where(i => i >= numbers.Average()).ToList();

            switch(command)
            {
                case "Min":
                    Console.WriteLine(numbers.Min());
                    break;

                case "Max":
                    Console.WriteLine(numbers.Max());
                    break;

                case "All":
                    numbers = numbers.OrderBy(i => i).ToList();
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
            }
        }
    }
}

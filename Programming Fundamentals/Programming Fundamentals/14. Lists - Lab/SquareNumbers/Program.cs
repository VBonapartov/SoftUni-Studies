using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            List<int> squareNums = new List<int>();
            foreach (int number in listNumbers)
            {
                if(Math.Sqrt(number) == (int)Math.Sqrt(number))
                {
                    squareNums.Add(number);
                }
            }

            squareNums.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ", squareNums));
        }
    }
}

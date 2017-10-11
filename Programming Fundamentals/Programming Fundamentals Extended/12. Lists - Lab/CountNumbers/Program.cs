using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            listNumbers.Sort();
            var listNumbersGrouped = listNumbers.GroupBy(x => x);

            foreach (var result in listNumbersGrouped)
            {
                Console.WriteLine($"{result.Key} -> {result.Count()}");
            }

            //List<int> distListNumbers = listNumbers.Distinct().ToList();
            //distListNumbers.Sort();

            //for(int i = 0; i < distListNumbers.Count; i++)
            //{
            //    int number = distListNumbers[i];
            //    int count = listNumbers.Where(x => x == number).Count();
            //    Console.WriteLine($"{number} -> {count}");
            //}
        }
    }
}

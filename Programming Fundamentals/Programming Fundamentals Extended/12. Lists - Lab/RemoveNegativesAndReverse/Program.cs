using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listIntegers = Console.ReadLine().Split(' ').Select(int.Parse).Where(x => x >= 0).ToList();

            if (listIntegers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                listIntegers.Reverse();
                foreach (int item in listIntegers)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

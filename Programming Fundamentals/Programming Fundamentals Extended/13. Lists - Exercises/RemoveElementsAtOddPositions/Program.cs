using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveElementsAtOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Trim().Split(' ').ToList();

            for(int i = 0; i < input.Count; i = i + 2)
            {
                input.RemoveAt(i);
                i--;
            }

            Console.WriteLine(string.Join("", input));
        }
    }
}

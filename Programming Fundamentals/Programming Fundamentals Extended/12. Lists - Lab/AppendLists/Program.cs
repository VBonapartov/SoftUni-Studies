using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split('|');

            List<int> result = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                string[] tre = input[i].Trim().Split(' ');
                List<int> listIntegers = input[i].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                result.AddRange(listIntegers);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

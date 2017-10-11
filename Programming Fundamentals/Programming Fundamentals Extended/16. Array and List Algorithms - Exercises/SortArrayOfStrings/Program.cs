using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayStr = Console.ReadLine().Split(' ');

            List<string> result = InsertionSortAlgorithm(arrayStr);
            Console.WriteLine(string.Join(" ", result));
        }

        static private List<string> InsertionSortAlgorithm(string[] array)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                int index = -1;
                for (int p = result.Count - 1; p >= 0; p--)
                {
                    if (array[i].CompareTo(result[p]) != -1)
                    {
                        index = p;
                        break;
                    }
                }

                result.Insert(index + 1, array[i]);
            }

            return result;
        }
    }
}

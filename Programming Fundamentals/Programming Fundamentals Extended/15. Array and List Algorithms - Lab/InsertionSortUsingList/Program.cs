using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortUsingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            List<int> result = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                int index = -1;
                for (int p = result.Count - 1; p >= 0; p--)
                {
                    if (nums[i] > result[p])
                    {
                        index = p;
                        break;
                    }
                }

                result.Insert(index + 1, nums[i]);
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}

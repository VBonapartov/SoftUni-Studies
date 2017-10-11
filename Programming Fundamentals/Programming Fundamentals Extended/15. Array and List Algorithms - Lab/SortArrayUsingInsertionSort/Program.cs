using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayUsingInsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            for(int i = 1; i < nums.Count; i++)
            {
                int index = -1;
                for(int p = i - 1; p >= 0; p--)
                {
                    if(nums[i] > nums[p])
                    {
                        index = p;
                        break;
                    }
                }

                nums.Insert(index + 1, nums[i]);
                nums.RemoveAt(i + 1);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

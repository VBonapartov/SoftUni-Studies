using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayUsingBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        int item = nums[i];
                        nums.RemoveAt(i);
                        nums.Insert(i + 1, item);

                        swapped = true;
                    }
                }
            } while (swapped);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

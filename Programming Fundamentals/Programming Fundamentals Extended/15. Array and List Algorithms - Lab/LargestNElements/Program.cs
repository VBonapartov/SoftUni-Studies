using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            SortListDescendingOrder(nums);
            PrintFirstNItem(nums, n);
        }

        static private void SortListDescendingOrder(List<int> nums)
        {
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i] < nums[i + 1])
                    {
                        int item = nums[i];
                        nums.RemoveAt(i);
                        nums.Insert(i + 1, item);

                        swapped = true;
                    }
                }
            } while (swapped);
        }

        static private void PrintFirstNItem(List<int> nums, int n)
        {
            for(int i = 0; i < n; i++)
            {
                Console.Write(nums[i] + " ");
            }

            Console.WriteLine();
        }
    }
}

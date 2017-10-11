using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayInPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            int numsLen = nums.Length;
            int middle = numsLen / 2;
            for(int i = 0; i < middle; i++)
            {
                int currentItem = nums[i];
                nums[i] = nums[numsLen - 1 - i];
                nums[numsLen - 1 - i] = currentItem;
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

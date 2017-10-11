using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            int smallestInt = int.MaxValue;
            for(int i = 0; i < nums.Length; i++)
            {
                smallestInt = Math.Min(smallestInt, nums[i]);
            }

            Console.WriteLine(smallestInt);
        }
    }
}

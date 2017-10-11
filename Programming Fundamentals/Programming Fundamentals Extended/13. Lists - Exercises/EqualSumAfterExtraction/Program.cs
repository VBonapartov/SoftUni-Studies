using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumAfterExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            for(int i = 0; i < nums1.Count; i++)
            {
                while(nums2.Contains(nums1[i]))
                    nums2.Remove(nums1[i]);
            }

            int diff = nums1.Sum() - nums2.Sum();
            if(diff == 0)
            {
                Console.WriteLine($"Yes. Sum: {nums1.Sum()}");
            }
            else
            {
                Console.WriteLine($"No. Diff: {Math.Abs(diff)}");
            }
        }
    }
}

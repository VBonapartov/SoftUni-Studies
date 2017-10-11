using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuckZipper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            int[] lenNums1 = nums1.Select(x => { return Math.Abs(x).ToString().Length; }).ToArray();     
            int[] lenNums2 = nums2.Select(x => { return Math.Abs(x).ToString().Length; }).ToArray();

            int minLength = Math.Min(lenNums1.Min(), lenNums2.Min());
            nums1.RemoveAll(x => Math.Abs(x).ToString().Length > minLength);
            nums2.RemoveAll(x => Math.Abs(x).ToString().Length > minLength);

            List<int> result = new List<int>();
            int maxIndex = Math.Max(nums1.Count, nums2.Count);
            for (int i = 0; i <= maxIndex; i++)
            {
                if (i < nums2.Count)
                    result.Add(nums2[i]);

                if (i < nums1.Count)
                    result.Add(nums1[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

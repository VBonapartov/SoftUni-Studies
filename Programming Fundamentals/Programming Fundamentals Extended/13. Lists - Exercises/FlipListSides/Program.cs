using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipListSides
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
                        
            int firstElement = nums[0];
            int lastElement = nums[nums.Count - 1];
            nums.Reverse();

            nums.RemoveAt(0);
            nums.RemoveAt(nums.Count - 1);
            nums.Insert(0, firstElement);
            nums.Add(lastElement);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

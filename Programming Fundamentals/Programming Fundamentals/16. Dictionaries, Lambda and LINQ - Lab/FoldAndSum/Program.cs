using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            // Row1 array left and right part
            int k = nums.Length / 4;
            int[] leftPart = nums.Take(k).Reverse().ToArray();
            int[] rightPart = nums.Skip(Math.Max(0, nums.Count() - k)).Reverse().ToArray();

            int[] row1 = new int[2 * k];
            leftPart.CopyTo(row1, 0);
            rightPart.CopyTo(row1, k);

            // Row2 array
            int[] row2 = nums.Skip(k).Take(2 * k).ToArray();

            // Sum the arrays row1 and row2
            int[] sum = row1.Select((x, index) => x + row2[index]).ToArray();
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

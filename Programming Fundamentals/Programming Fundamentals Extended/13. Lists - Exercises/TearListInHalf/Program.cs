using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TearListInHalf
{
    class Program
    {
        static void Main(string[] args)
        {
            List<byte> nums = Console.ReadLine().Trim().Split(' ').Select(byte.Parse).ToList();

            List<byte> leftHalf = nums.Take(nums.Count / 2).ToList();
            nums.Reverse();
            List<byte> rightHalf = nums.Take(nums.Count / 2).ToList();
            rightHalf.Reverse();

            List<byte> result = new List<byte>();
            for(int i = 0; i < leftHalf.Count; i++)
            {
                byte digit1 = (byte)(rightHalf[i] / 10);
                byte digit2 = (byte)(rightHalf[i] % 10);

                result.Add(digit1);
                result.Add(leftHalf[i]);
                result.Add(digit2);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}

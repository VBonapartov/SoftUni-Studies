using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayContainsElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            bool isFind = false;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == n)
                {
                    isFind = true;
                    break;
                }
            }

            if(isFind)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

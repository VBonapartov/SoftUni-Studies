using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> nums = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToList();

            long sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                long number = nums[i];

                if (number > 0)
                {
                    StringBuilder strNum = new StringBuilder();
                    while (number > 0)
                    {
                        int lastDigit = (int)(number % 10);
                        strNum.Append(lastDigit);

                        number /= 10;
                    }

                    sum += Convert.ToInt32(strNum.ToString());
                }
            }

            Console.WriteLine(sum);
        }
    }
}

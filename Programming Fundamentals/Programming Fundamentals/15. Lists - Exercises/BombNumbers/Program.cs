using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            List<int> specialNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            int index = 0;
            int power = specialNumbers[1];

            List <int> result = new List<int>();
            while ((index = nums.IndexOf(specialNumbers[0])) != -1)
            {                
                for (int i = 0; i < nums.Count; i++)
                {
                    if ((i >= index - power) && (i <= index + power))
                        continue;

                    result.Add(nums[i]);
                }

                nums.Clear();
                nums.AddRange(result);
                result.Clear();
            }

            Console.WriteLine(nums.Sum());
        }
    }
}

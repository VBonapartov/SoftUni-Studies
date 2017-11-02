using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToList();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (counts.ContainsKey(nums[i]))
                {
                    counts[nums[i]]++;
                }
                else
                {
                    counts[nums[i]] = 1;
                }
            }

            foreach (KeyValuePair<double, int> p in counts)
            {
                Console.WriteLine("{0} -> {1}", p.Key, p.Value);
            }
        }
    }
}

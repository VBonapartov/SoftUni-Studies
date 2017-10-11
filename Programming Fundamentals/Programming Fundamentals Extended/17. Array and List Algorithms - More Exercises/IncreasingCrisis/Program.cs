using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingCrisis
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> result = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                //Test input!
                //2
                //1 3 5
                //4 6 8
                //1 3 4 6 8 -> result
                List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

                if(result.Count == 0)
                {
                    result.AddRange(nums);
                }
                else
                {                    
                    int index = -1;
                    for(int idx = result.Count - 1; idx >= 0; idx--)
                    {
                        if(result[idx] <= nums[0])
                        {
                            index = idx;
                            break;
                        }
                    }

                    result.Insert(++index, nums[0]);
                    for (int p = 1; p < nums.Count; p++)
                    {
                        if (nums[p] >= nums[p - 1])
                        {
                            result.Insert(++index, nums[p]);

                            if (index < result.Count - 1 && result[index] > result[index + 1])
                            {
                                result = result.Take(index + 1).ToList();
                                break;
                            }
                        }
                        else
                        {
                           result = result.Take(index + 1).ToList();
                           break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

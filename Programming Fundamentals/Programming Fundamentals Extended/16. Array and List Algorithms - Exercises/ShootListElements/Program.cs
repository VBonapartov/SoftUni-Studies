using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootListElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            int lastRemovedInt = 0;
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("stop"))
            {
                if(input.Equals("bang"))
                {
                    if (nums.Count > 0)
                    {
                        int index = (nums.Count == 1) ? 0 : nums.Select((s, i) => new { i, s }).Where(t => t.s < nums.Average()).Select(t => t.i).ToList()[0];

                        lastRemovedInt = nums[index];
                        nums.RemoveAt(index);
                        nums = nums.Select(x => --x).ToList();

                        Console.WriteLine($"shot {lastRemovedInt}");                        
                    }
                    else
                        break;
                }
                else
                {
                    int number = Convert.ToInt32(input);
                    nums.Insert(0, number);
                }
            }
            
            if(nums.Count == 0) 
            {
                if (input.Equals("bang"))
                {
                    Console.WriteLine($"nobody left to shoot! last one was {lastRemovedInt}");
                }
                else
                {
                    Console.WriteLine($"you shot them all. last one was {lastRemovedInt}");
                }
            }
            else
            {
                Console.WriteLine($"survivors: " + string.Join(" ", nums));
            }
        }
    }
}

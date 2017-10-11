using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorImage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Trim().Split(' ').ToList();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Print"))
            {
                int index = Convert.ToInt32(input);

                nums.Reverse(0, index);
                nums.Reverse(index + 1, nums.Count - index - 1);
            }

            Console.WriteLine(string.Join(" ", nums));          
        }
    }
}

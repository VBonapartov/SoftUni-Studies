using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInsertion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                int number = Convert.ToInt32(input);
                int index = Convert.ToInt32(input[0].ToString());

                nums.Insert(index, number);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

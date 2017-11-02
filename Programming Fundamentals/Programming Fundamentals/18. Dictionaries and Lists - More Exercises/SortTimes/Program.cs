using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split(' ');

            List<DateTime> times = new List<DateTime>();
            for (int i = 0; i < input.Length; i++)
            {
                DateTime time = Convert.ToDateTime(input[i]); 
                times.Add(time);
             }

            List<string> sortedTimes = times.OrderBy(x => x.TimeOfDay).Select(x => x.ToString("HH:mm")).ToList();
            Console.WriteLine($"{string.Join(", ", sortedTimes)}");
        }
    }
}

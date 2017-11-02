using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine("[" + string.Join(", ", input.Split(new[] { delimiter }, StringSplitOptions.None)) + "]");
        }
    }
}

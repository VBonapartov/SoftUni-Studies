using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableInHexadecimalFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int number = Convert.ToInt32(input, 16);
            Console.WriteLine(number);
        }
    }
}

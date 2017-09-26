using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                if ((number & 1) == 0)
                {
                    output.Append("Please write an odd number.\n");
                }
                else
                {
                    output.AppendFormat($"The number is: {Math.Abs(number)}\n");
                    break;
                }
            }

            Console.Write(output);
        }
    }
}

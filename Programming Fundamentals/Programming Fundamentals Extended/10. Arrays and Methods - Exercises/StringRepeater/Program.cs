using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRepeater
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = RepeatString(inputStr, n);
            Console.WriteLine(result);
        }

        static private string RepeatString(string str, int count)
        {
            StringBuilder result = new StringBuilder();
            for(int i = 1; i <= count; i++)
            {
                result.Append(str);
            }

            return result.ToString();
        }
    }
}

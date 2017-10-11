using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();
            for(int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                output.Append((char)number);
            }

            Console.WriteLine(output);
        }
    }
}

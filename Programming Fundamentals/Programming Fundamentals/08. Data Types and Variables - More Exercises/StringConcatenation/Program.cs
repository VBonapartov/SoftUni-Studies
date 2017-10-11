using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringConcatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimiter = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();
            for(int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                if(i % 2 == 0 && evenOrOdd.Equals("even"))
                {
                    output.AppendFormat("{0}{1}", (output.Length > 0) ? delimiter.ToString() : "", input);
                }

                if (i % 2 != 0 && evenOrOdd.Equals("odd"))
                {
                    output.AppendFormat("{0}{1}", (output.Length > 0) ? delimiter.ToString() : "", input);
                }
            }

            Console.WriteLine(output);
        }
    }
}

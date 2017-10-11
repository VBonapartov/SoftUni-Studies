using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string delimiter = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();
            
            for(int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                if(input.Equals("") || input.Equals(" "))
                {
                    output.Append(delimiter);
                }
                else
                {
                    output.Append(input);
                    if (i != n)
                    {
                        output.Append(delimiter);
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}

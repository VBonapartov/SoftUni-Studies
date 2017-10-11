using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool appendEnd = true;
            string previousString = string.Empty;
            StringBuilder cypherString = new StringBuilder();
            while(n > 0)
            {
                string input = Console.ReadLine();

                if(previousString.Equals(input))
                {
                    cypherString.Clear(); 
                    if (input.Equals("spin"))
                    {
                        continue;
                    }                    
                }
                else if(input.Equals("spin"))
                {
                    previousString = input;
                    appendEnd = !appendEnd;
                    continue;
                }
                else
                {
                    previousString = input;
                    if (appendEnd)
                    {
                        cypherString.Append(input);
                    }
                    else
                    {
                        cypherString.Insert(0, input);
                    }
                }
                n--;
            }

            Console.WriteLine(cypherString);
        }
    }
}




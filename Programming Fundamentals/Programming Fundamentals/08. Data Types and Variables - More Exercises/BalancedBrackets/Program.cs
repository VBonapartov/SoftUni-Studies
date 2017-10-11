using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int balanced = 0;
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                if(input.Equals("("))
                {
                    if (balanced > 0)
                        break;

                    balanced++;
                }
                else if (input.Equals(")"))
                {
                    if(balanced != 1)
                    {
                        balanced++;
                        break;
                    }

                    balanced--;
                }
                else
                {
                    continue;
                }                
            }

            if (balanced == 0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}

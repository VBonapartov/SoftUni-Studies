using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string charsPositions = GetCharsPositions(input);
            Console.WriteLine(charsPositions);
        }

        private static string GetCharsPositions(string input)
        {
            string distinctChars = new string(input.Distinct().ToArray());

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < distinctChars.Length; i ++)
            {
                char ch = distinctChars[i];

                if(result.Length > 0)
                    result.Append(Environment.NewLine);

                result.Append(ch + ":");
                for(int p = 0; p < input.Length; p++)
                {
                    if (ch.Equals(input[p]))
                    {
                        if (!result[result.Length - 1].Equals(':'))
                            result.Append("/");

                        result.Append(p);
                    }
                }
            }

            return result.ToString();
        }
    }
}

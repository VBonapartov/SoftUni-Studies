namespace _01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // [(wordSymbols)<(Some digits)REGEH(Some digits)>(wordSymbols)]
            string pattern = @"(\[\w+<(?<firstNumber>\d+)REGEH(?<secondNumber>\d+)>\w+\])";

            // [(ASCII Symbols)<(Some digits)REGEH(Some digits)>(ASCII Symbols)]
            //string pattern = @"(\[[^\s\[\]]*<(?<firstNumber>\d+)REGEH(?<secondNumber>\d+)>[^\s\[\]]*\])";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<int> numbers = new List<int>();

            foreach (Match match in matches)
            {
                int firstNumber = int.Parse(match.Groups["firstNumber"].Value);
                int secondNumber = int.Parse(match.Groups["secondNumber"].Value);

                numbers.Add(firstNumber);
                numbers.Add(secondNumber);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numbers.Count; i++)
            {
                long index = numbers[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    index += numbers[j];
                }

                index %= input.Length - 1;
                result.Append(input[(int)index]);
            }

            Console.WriteLine(result);
        }
    }
}

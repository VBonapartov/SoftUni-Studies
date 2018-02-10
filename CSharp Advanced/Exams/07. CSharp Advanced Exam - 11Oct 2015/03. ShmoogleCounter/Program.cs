namespace _03.ShmoogleCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> code = ReadCode();
            GetDoublesAndInts(code);
        }

        private static List<string> ReadCode()
        {
            List<string> code = new List<string>();

            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("//END_OF_CODE"))
            {
                code.Add(input);
            }

            return code;
        }

        private static void GetDoublesAndInts(List<string> code)
        {
            List<string> ints = new List<string>();
            List<string> doubles = new List<string>();

            string pattern = @"\b(int|double)\s([a-z][a-zA-Z]{0,24})";

            foreach (string line in code)
            {
                MatchCollection matches = Regex.Matches(line, pattern);

                foreach (Match match in matches)
                {
                    string typeOfVariable = match.Groups[1].Value;
                    string nameOfVariable = match.Groups[2].Value;

                    if (typeOfVariable.Equals("int"))
                    {
                        ints.Add(nameOfVariable);
                    }
                    else if (typeOfVariable.Equals("double"))
                    {
                        doubles.Add(nameOfVariable);
                    }
                }
            }

            PrintResult(doubles, "Doubles");
            PrintResult(ints, "Ints");
        }

        static void PrintResult(List<string> listOfVariables, string typeOfvariable)
        {
            listOfVariables.Sort();
            string outputVariables = (listOfVariables.Count() > 0) ? string.Join(", ", listOfVariables)  : "None";

            Console.WriteLine("{0}: {1}", typeOfvariable, outputVariables);
        }
    }
}

namespace _17.BiggestTableRow
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputTable = GetInputData();
            BiggestTableRow(inputTable);
        }

        private static List<string> GetInputData()
        {
            List<string> inputTable = new List<string>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("</table>"))
            {
                inputTable.Add(input);
            }

            inputTable.RemoveAt(0);
            inputTable.RemoveAt(0);
            return inputTable;
        }

        private static void BiggestTableRow(List<string> inputTable)
        {
            string pattern = @"<td>(?<number>[+-]*\d+\.*\d*)<\/td>";

            double maxSum = double.MinValue;
            List<string> maxOperands = new List<string>();

            foreach(string row in inputTable)
            {
                double currentSum = 0.0d;
                List<string> currentOperands = new List<string>();

                MatchCollection matches = Regex.Matches(row, pattern);

                foreach(Match match in matches)
                {
                    double decValue;
                    if(double.TryParse(match.Groups["number"].Value, out decValue))
                    {
                        currentSum += decValue;
                        currentOperands.Add(match.Groups["number"].Value);
                    }
                }

                if(currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxOperands = currentOperands;
                }
            }

            PrintResult(maxSum, maxOperands);
        }

        private static void PrintResult(double maxSum, List<string> maxOperands)
        {
            if(maxOperands.Count == 0)
            {
                Console.WriteLine("no data");
                return;
            }

            Console.WriteLine($"{maxSum} = {string.Join(" + ", maxOperands)}");
        }
    }
}

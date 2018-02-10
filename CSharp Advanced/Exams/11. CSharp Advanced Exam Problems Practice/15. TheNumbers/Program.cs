namespace _15.TheNumbers
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            CleanUpMessages(inputData);
        }

        private static void CleanUpMessages(string inputData)
        {
            StringBuilder sb = new StringBuilder();

            string pattern = @"(?<number>\d+)";

            MatchCollection matches = Regex.Matches(inputData, pattern);

            foreach (Match match in matches)
            {
                string number = match.Groups["number"].Value;
                string hexNumberAsString = ConvertNumberToHEX(number);

                if (!hexNumberAsString.Equals(""))
                {
                    sb.Append(hexNumberAsString + "-");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd('-'));
        }

        private static string ConvertNumberToHEX(string numberAsStr)
        {
            string hexValue = string.Empty;

            int decValue;
            if(int.TryParse(numberAsStr, out decValue))
            {
                hexValue = decValue.ToString("X");
                
                if(hexValue.Length < 4)
                {
                    hexValue = hexValue.PadLeft(4, '0');
                }

                hexValue = "0x" + hexValue;
            }

            return hexValue;
        }
    }
}

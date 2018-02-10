namespace _03.SoftuniNumerals
{
    using System;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        private static string[] numbersAsStr = new string[] { "aa", "aba", "bcc", "cc", "cdc" };
        private static int Base = 5;

        static void Main(string[] args)
        {            
            string text = Console.ReadLine();

            StringBuilder numberAsStr = ConvertTextToNumberAsStr(text);
            BigInteger number = BigInteger.Parse(numberAsStr.ToString());
            BigInteger decimalNumber = ConvertNumber(number, Base);

            Console.WriteLine(decimalNumber);
        }

        private static StringBuilder ConvertTextToNumberAsStr(string text)
        {
            StringBuilder numberAsStr = new StringBuilder();
            MatchCollection matches = Regex.Matches(text, $"aa|aba|bcc|cc|cdc");

            foreach (Match match in matches)
            {
                numberAsStr.Append(Array.IndexOf(numbersAsStr, match.Value));
            }

            return numberAsStr;
        }

        public static BigInteger ConvertNumber(BigInteger value, int toBase)
        {
            string numberAsStr = value.ToString();            
            BigInteger result = 0;

            BigInteger n = 1;

            for (int i = numberAsStr.Length - 1; i >= 0; --i)
            {
                result += n * int.Parse(numberAsStr[i].ToString());
                n *= toBase;
            }

            return result;
        }
    }
}

namespace _03._CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string text = GetCryptoBlockchain();
            List<string> validCryptoBlocks = GetValidCryptoBlocks(text);
            ConvertDigitsInCryptoBlocks(validCryptoBlocks);
        }

        private static string GetCryptoBlockchain()
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < numberOfRows; row++)
            {
                sb.Append(Console.ReadLine());
            }

            return sb.ToString();
        }

        private static List<string> GetValidCryptoBlocks(string text)
        {
            List<string> validCryptoBlocks = new List<string>();

            string cryptoBlockPattern = @"[\[\{].*?(?<digits>\d{3,}).*?[\]\}]";

            MatchCollection matches = Regex.Matches(text, cryptoBlockPattern);

            foreach (Match match in matches)
            {
                string cryptoBlock = match.Value;
                string digits = match.Groups["digits"].Value;

                if (IsCryptoBlockValid(cryptoBlock, digits))
                {
                    validCryptoBlocks.Add(cryptoBlock);
                }
            }

            return validCryptoBlocks;
        }

        private static bool IsCryptoBlockValid(string cryptoBlock, string digits)
        {
            char firstLetter = cryptoBlock[0];
            char lastLetter = cryptoBlock[cryptoBlock.Length - 1];

            if (firstLetter.Equals('[') && !lastLetter.Equals(']'))
            {
                return false;
            }

            if (firstLetter.Equals('{') && !lastLetter.Equals('}'))
            {
                return false;
            }

            if (digits.Length % 3 != 0)
            {
                return false;
            }

            return true;
        }

        private static void ConvertDigitsInCryptoBlocks(List<string> validCryptoBlocks)
        {
            StringBuilder result = new StringBuilder();

            string digitsPattern = @".*?(?<digits>\d{3,}).*?";

            foreach (string cryptoBlock in validCryptoBlocks)
            {
                int cryptoBlockLength = cryptoBlock.Length;

                Match match = Regex.Match(cryptoBlock, digitsPattern);
                string digits = match.Groups["digits"].Value;

                int startIndex = 0;
                while (startIndex < digits.Length)
                {
                    char letter = (char)(int.Parse(digits.Substring(startIndex, 3)) - cryptoBlockLength);

                    result.Append(letter);
                    startIndex += 3;
                }
            }

            Console.WriteLine(result);
        }
    }
}

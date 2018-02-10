namespace _11.LittleJohn
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = ReadInput();

            int encryptMessage = CreateEncryptedMessage(FindArrows(input));
            Console.WriteLine(encryptMessage);
        }

        private static List<string> ReadInput()
        {
            List<string> input = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                input.Add(Console.ReadLine());
            }

            return input;
        }

        private static string ConvertDecToBin(int number)
        {
            return Convert.ToString(number, 2);
        }

        private static int ConvertBinToDec(string number)
        {
            return Convert.ToInt32(number, 2);
        }

        private static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static int FindArrows(List<string> input)
        {
            int countSmallArrow = 0;
            int countMediumArrow = 0;
            int countLargeArrow = 0;

            foreach (string str in input)
            {
                MatchCollection matches = Regex.Matches(str, $"(>----->)|(>>----->)|(>>>----->>)");

                foreach (Match match in matches)
                {
                    countSmallArrow += match.Groups[1].Captures.Count;
                    countMediumArrow += match.Groups[2].Captures.Count;
                    countLargeArrow += match.Groups[3].Captures.Count;
                }
            }

            return int.Parse(countSmallArrow.ToString() + countMediumArrow.ToString() + countLargeArrow.ToString());
        }

        private static int CreateEncryptedMessage(int number)
        {
            string binary = ConvertDecToBin(number);
            string binaryReverse = ReverseString(binary);

            int encryptedMessage = ConvertBinToDec(binary + binaryReverse);
            return encryptedMessage;
        }
    }
}

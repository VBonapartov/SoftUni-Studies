namespace _03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = GetAllValidMessages();
            GetVerificationCodes(messages);
        }

        private static List<string> GetAllValidMessages()
        {
            List<string> messages = new List<string>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("Over!"))
            {
                string message = input;
                int messageLength = int.Parse(Console.ReadLine());

                string pattern = @"^\d*[a-zA-Z]{" + messageLength + @"}[^a-zA-Z]*$";

                if(Regex.IsMatch(message,pattern))
                {
                    messages.Add(message);
                }
            }

            return messages;
        }

        private static void GetVerificationCodes(List<string> validMessages)
        {
            foreach (string validMessage in validMessages)
            {
                StringBuilder verificationCode = new StringBuilder();
                 
                string message = GetMessage(validMessage);
                string digits = GetDigitsFromMsg(validMessage);

                foreach(char digit in digits)
                {
                    int index = int.Parse(digit.ToString());

                    if(index < 0 || index > message.Length - 1)
                    {
                        verificationCode.Append(" ");
                    }
                    else
                    {
                        verificationCode.Append(message[index]);
                    }
                }

                Console.WriteLine($"{message} == {verificationCode}");
            }
        }

        private static string GetMessage(string validMessage)
        {
            string pattern = @"^\d*(?<message>[a-zA-Z]+?)[^a-zA-Z]*$";
            Match match = Regex.Match(validMessage, pattern);

            return match.Groups["message"].Value;
        }

        private static string GetDigitsFromMsg(string message)
        {
            return Regex.Replace(message, @"[^0-9]+", "");
        }
    }
}

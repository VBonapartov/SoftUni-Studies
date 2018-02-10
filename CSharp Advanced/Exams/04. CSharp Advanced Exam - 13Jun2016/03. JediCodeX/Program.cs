namespace _03.JediCodeX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = GetEncodedMessages();
            List<string> patterns = GetPatterns();

            List<string> names = ExtractAllNames(input, patterns[0]);
            List<string> messages = ExtractAllMessages(input, patterns[1]);
            
            PrintResult(names, messages);
        }

        private static StringBuilder GetEncodedMessages()
        {
            StringBuilder sb = new StringBuilder();

            int numberOfLines = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfLines; i++)
            {
                sb.Append(Console.ReadLine());
            }

            return sb;
        }

        private static List<string> GetPatterns()
        {
            List<string> patterns = new List<string>();

            patterns.Add(Console.ReadLine());
            patterns.Add(Console.ReadLine());

            return patterns;
        }

        private static List<string> ExtractAllNames(StringBuilder input, string pattern)
        {
            List<string> allNames = new List<string>();

            string regexPattern = pattern + @"(?<name>[a-zA-Z]{" + pattern.Length + @"})(?![a-zA-Z])";

            MatchCollection matches = Regex.Matches(input.ToString(), regexPattern);

            foreach (Match match in matches)
            {
                allNames.Add(match.Groups["name"].Value);
            }

            return allNames;
        }

        private static List<string> ExtractAllMessages(StringBuilder input, string pattern)
        {
            List<string> allMessages = new List<string>();

            string regexPattern = pattern + @"(?<message>[a-zA-Z0-9]{" + pattern.Length + @"})(?![a-zA-Z0-9])";

            MatchCollection matches = Regex.Matches(input.ToString(), regexPattern);

            foreach (Match match in matches)
            {
                allMessages.Add(match.Groups["message"].Value);
            }

            return allMessages;
        }

        private static void PrintResult(List<string> names, List<string> messages)
        {
            Queue<int> indecies = new Queue<int>(Console.ReadLine()
                                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(int.Parse)
                                                     .ToArray()
                                                );

            foreach (string name in names)
            {
                while (indecies.Count > 0)
                {
                    int index = indecies.Dequeue() - 1;

                    if (index >= 0 && index < messages.Count)
                    {
                        Console.WriteLine($"{name} - {messages[index]}");
                        break;
                    }
                }
            }
        }
    }
}

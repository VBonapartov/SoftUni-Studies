using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HornetComm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> messages = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> broadcasts = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Hornet is Green"))
            {
                string[] queries = input.Split(new string[] { " <-> " }, StringSplitOptions.None);

                if (queries.Length != 2)
                    continue;

                string firstQuery = queries[0];
                string secondQuery = queries[1];

                bool isPrivateMessage = IsPrivateMessage(firstQuery, secondQuery);
                bool isBroadcast = IsBroadcast(firstQuery, secondQuery);

                if(isPrivateMessage)
                {
                    messages = PrivateMessage(messages, firstQuery, secondQuery);
                }
                else if(isBroadcast)
                {
                    broadcasts = Broadcast(broadcasts, firstQuery, secondQuery);
                }
            }

            PrintBroadcastsAndMessages(broadcasts, messages);
        }

        private static bool IsPrivateMessage(string firstQuery, string secondQuery)
        {
            string patternFirstQuery = @"^[0-9]+$";
            string patternSecondQuery = @"^[A-Za-z0-9]+$";

            bool isMatchFirstQuery = Regex.IsMatch(firstQuery, patternFirstQuery);
            bool isMatchSecondQuery = Regex.IsMatch(secondQuery, patternSecondQuery);

            return isMatchFirstQuery && isMatchSecondQuery;
        }

        private static bool IsBroadcast(string firstQuery, string secondQuery)
        {
            string patternFirstQuery = @"^[^0-9]+$";
            string patternSecondQuery = @"^[A-Za-z0-9]+$";

            bool isMatchFirstQuery = Regex.IsMatch(firstQuery, patternFirstQuery);
            bool isMatchSecondQuery = Regex.IsMatch(secondQuery, patternSecondQuery);

            return isMatchFirstQuery && isMatchSecondQuery;
        }

        private static Dictionary<string, List<string>> PrivateMessage(Dictionary<string, List<string>> messages, string firstQuery, string secondQuery)
        {       
            firstQuery = new string(firstQuery.Reverse().ToArray());
            if(messages.ContainsKey(firstQuery))
            {
                messages[firstQuery].Add(secondQuery);
            }
            else
            {
                messages.Add(firstQuery, new List<string> { secondQuery });
            }

            return messages;
        }

        private static Dictionary<string, List<string>> Broadcast(Dictionary<string, List<string>> broadcasts, string firstQuery, string secondQuery)
        {
            secondQuery = new string(secondQuery
                                            .Select(ch =>
                                                        {
                                                            if (Char.IsUpper(ch))
                                                                return Char.ToLower(ch);
                                                            else
                                                                return Char.ToUpper(ch);
                                                        }
                                                    )
                                            .ToArray()
                                     );

            if (broadcasts.ContainsKey(secondQuery))
            {
                broadcasts[secondQuery].Add(firstQuery);
            }
            else
            {
                broadcasts.Add(secondQuery, new List<string> { firstQuery });
            }

            return broadcasts;
        }

        private static void PrintBroadcastsAndMessages(Dictionary<string, List<string>> broadcasts, Dictionary<string, List<string>> messages)
        {
            PrintBroadcasts(broadcasts);
            PrintMessages(messages);
        }

        private static void PrintBroadcasts(Dictionary<string, List<string>> broadcasts)
        {
            Console.WriteLine("Broadcasts:");

            if(broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (KeyValuePair<string, List<string>> broadcast in broadcasts)
                    foreach (string message in broadcast.Value)
                    {
                        Console.WriteLine($"{broadcast.Key} -> {message}");
                    }
            }
        }

        private static void PrintMessages(Dictionary<string, List<string>> messages)
        {
            Console.WriteLine("Messages:");

            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (KeyValuePair<string, List<string>> recipientCode in messages)
                    foreach (string message in recipientCode.Value)
                    {
                        Console.WriteLine($"{recipientCode.Key} -> {message}");
                    }
            }
        }
    }
}

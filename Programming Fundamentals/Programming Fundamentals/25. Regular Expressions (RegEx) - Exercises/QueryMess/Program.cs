using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput();            
        }

        private static void ReadInput()
        {         
            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                keyValuePairs = GetKeyValuePairs(input);
                PrintKeyValue(keyValuePairs);
            }
        }

        private static Dictionary<string, List<string>> GetKeyValuePairs(string input)
        {
            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();

            string pattern = @"(?<key>[^\=\&\?]+)=(?<value>[^\=\&\?]+)";
            MatchCollection pairMatches = Regex.Matches(input, pattern);
            foreach (Match pair in pairMatches)
            {
                string key = pair.Groups["key"].Value;
                string value = pair.Groups["value"].Value;

                key = Regex.Replace(key, @"(\+|%20)+", " ").Trim();
                value = Regex.Replace(value, @"(\+|%20)+", " ").Trim();

                if (keyValuePairs.ContainsKey(key))
                {
                    keyValuePairs[key].Add(value);
                }
                else
                {
                    keyValuePairs.Add(key, new List<string> { value });
                }
            }

            return keyValuePairs;
        }

        private static void PrintKeyValue(Dictionary<string, List<string>> keyValuePairs)
        {
            StringBuilder output = new StringBuilder();
            foreach(KeyValuePair<string, List<string>> keyValue in keyValuePairs)
            {
                output.AppendFormat($"{keyValue.Key}=[{string.Join(", ", keyValue.Value)}]");
            }

            Console.WriteLine(output);
        }
    }
}

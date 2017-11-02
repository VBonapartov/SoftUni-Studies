using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializeString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> charsPositions = ReadInput();
            string result = DeserializeString(charsPositions);

            Console.WriteLine(result);
        }

        private static Dictionary<string, List<int>> ReadInput()
        {
            Dictionary<string, List<int>> charsPositions = new Dictionary<string, List<int>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("end"))
            {
                string[] tokens = input.Split(':');

                List<int> indexes = tokens[1].Split('/').Select(s => Convert.ToInt32(s)).ToList();
                charsPositions.Add(tokens[0], indexes);
            }

            return charsPositions;
        }

        private static string DeserializeString(Dictionary<string, List<int>> charsPositions)
        {
            int lenOfString = charsPositions.Select(c => c.Value.Count).Sum();

            StringBuilder result = new StringBuilder(new string(' ', lenOfString));
            foreach(KeyValuePair<string, List<int>> charPos in charsPositions)
            {
                foreach(int index in charPos.Value)
                {
                    result[index] = Convert.ToChar(charPos.Key);
                }
            }

            return result.ToString();
        }
    }
}

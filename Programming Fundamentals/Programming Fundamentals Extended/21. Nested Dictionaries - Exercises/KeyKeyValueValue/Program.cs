using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyKeyValueValue
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine().Trim();
            string value = Console.ReadLine().Trim();
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> keyValue = new Dictionary<string, List<string>>();
            for(int i = 1; i <= n;  i++)
            {
                string[] input = Console.ReadLine().Trim().Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                string inputKey = input[0];
                string[] inputValue = input[1].Split(';');

                if(inputKey.Contains(key))
                {
                    if (!keyValue.ContainsKey(inputKey))
                    {
                        keyValue.Add(inputKey, new List<string>() { });
                    }

                    for (int p = 0; p < inputValue.Length; p++)
                    {
                        if (inputValue[p].Contains(value))
                        {
                            keyValue[inputKey].Add(inputValue[p]);
                        }
                    }
                }
            }

            foreach(KeyValuePair<string, List<string>> item in keyValue)
            {
                Console.WriteLine($"{item.Key}:");
                foreach(string values in item.Value)
                {
                    Console.WriteLine($"-{values}");
                }
            }
        }
    }
}

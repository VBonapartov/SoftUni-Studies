using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictRefAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dictRef = new Dictionary<string, List<int>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("end"))
            {
                string[] command = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string key = command[0];
                string[] inputValues = command[1].Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int number = 0;
                bool isNumber = int.TryParse(inputValues[0], out number);

                if (dictRef.ContainsKey(key))
                {
                    if (isNumber)
                    {
                        int[] values = inputValues.Select(int.Parse).ToArray();
                        dictRef[key].AddRange(values);
                    }
                    else
                    {
                        if (dictRef.ContainsKey(inputValues[0]))
                        {                            
                            dictRef[key].AddRange(new List<int>(dictRef[inputValues[0]]));
                        }
                    }
                }
                else
                {
                    if (isNumber)
                    {
                        dictRef.Add(key, inputValues.Select(int.Parse).ToList());
                    }
                    else
                    {
                        if (dictRef.ContainsKey(inputValues[0]))
                        {
                            dictRef.Add(key, new List<int>(dictRef[inputValues[0]]));
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, List<int>> name in dictRef)
            {
                Console.WriteLine($"{name.Key} === {string.Join(", ", name.Value)}");
            }
        }
    }
}

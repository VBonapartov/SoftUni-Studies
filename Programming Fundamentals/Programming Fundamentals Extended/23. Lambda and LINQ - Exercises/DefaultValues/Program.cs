using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> defaultValues = new Dictionary<string, string>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] command = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string key = command[0];
                string value = command[1];

                if (defaultValues.ContainsKey(key))
                {
                    defaultValues[key] = value;
                }
                else
                {
                    defaultValues.Add(key, value);
                }
                
            }

            string defaultValue = Console.ReadLine();

            var elementsWithValues = defaultValues.Where(s => !s.Value.Equals("null")).OrderByDescending(s => s.Value.Length);
            foreach (KeyValuePair<string, string> item in elementsWithValues)
            {
                Console.WriteLine($"{item.Key} <-> {item.Value}");
            }

            var elementsWithDefaultValues = defaultValues.Where(s => s.Value.Equals("null")).ToDictionary(s => s.Key, s => defaultValue);
            foreach (KeyValuePair<string, string> item in elementsWithDefaultValues)  
            {
                Console.WriteLine($"{item.Key} <-> {item.Value}");
            }
        }
    }
}

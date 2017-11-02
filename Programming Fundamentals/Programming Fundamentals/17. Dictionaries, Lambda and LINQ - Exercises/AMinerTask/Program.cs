using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            int currentLine = 1;
            string currentResource = string.Empty;
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("stop"))
            {
                if(currentLine % 2 != 0)
                {
                    currentResource = input;
                }
                else
                {
                    if (resources.ContainsKey(currentResource))
                    {
                        resources[currentResource] += int.Parse(input);
                    }
                    else
                    {
                        resources[currentResource] = int.Parse(input);
                    }
                }

                currentLine++;
            }

            PrintResources(resources);
        }

        static private void PrintResources(Dictionary<string, int> resources)
        {
            foreach (KeyValuePair<string, int> resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}

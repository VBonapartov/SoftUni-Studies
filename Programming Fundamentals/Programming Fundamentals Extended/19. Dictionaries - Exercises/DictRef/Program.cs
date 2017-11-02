using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictRef
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictRef = new Dictionary<string, int>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string[] command = input.Trim().Split(' ');
                string name = command[0];
                int number = 0;
                bool isNumber = int.TryParse(command[2], out number);

                if (dictRef.ContainsKey(name))
                {
                    if (isNumber)
                    {
                        dictRef[name] = number;
                    }
                    else
                    {
                        if (dictRef.ContainsKey(command[2]))
                        {
                            dictRef[name] = dictRef[command[2]];
                        }
                    }
                }
                else
                {
                    if (isNumber)
                    {
                        dictRef.Add(name, number);
                    }
                    else
                    {
                        if (dictRef.ContainsKey(command[2]))
                        {
                            dictRef.Add(name, dictRef[command[2]]);
                        }
                    }                   
                }
            }

            foreach(KeyValuePair<string, int> name in dictRef)
            {
                Console.WriteLine($"{name.Key} === {name.Value}");
            }
        }
    }
}

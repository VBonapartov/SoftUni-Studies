using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shellbound
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<long>> regionShells = new Dictionary<string, HashSet<long>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Aggregate"))
            {
                string[] command = input.Split(' ');
                string regionsName = command[0];
                int shellSize = Convert.ToInt32(command[1]);

                if(regionShells.ContainsKey(regionsName))
                {
                    regionShells[regionsName].Add(shellSize);
                }
                else
                {
                    regionShells.Add(regionsName, new HashSet<long>() { shellSize });
                }
            }

            foreach (KeyValuePair<string, HashSet<long>> item in regionShells)
            {
                long giantShell = (long)Math.Ceiling((item.Value.Sum() - item.Value.Average()));
                Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)} ({giantShell})");
            }
        }
    }
}

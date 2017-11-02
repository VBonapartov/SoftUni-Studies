using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();
            for(int i = 1; i <= n; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach(string name in names)
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = 0;
            while(true)
            {
                string input = Console.ReadLine();

                bool isNumeric = int.TryParse(input, out int n);
                if (!isNumeric)
                    break;

                countNumbers++;
            }

            Console.WriteLine($"{countNumbers}");
        }
    }
}

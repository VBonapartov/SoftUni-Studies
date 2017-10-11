using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            byte incVariable = 0;
            int overflowed = 0;
            for (int i = 1; i <= n; i++)
            {
                if (++incVariable == 0)
                {
                    overflowed++;
                }                
            }

            Console.WriteLine(incVariable);

            if (overflowed > 0)
            {
                Console.WriteLine($"Overflowed {overflowed} times");
            }                        
        }
    }
}

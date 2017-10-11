using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int max = GetMax(a, b);
            max = GetMax(max, c);
            Console.WriteLine(max);
        }

        static private int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}

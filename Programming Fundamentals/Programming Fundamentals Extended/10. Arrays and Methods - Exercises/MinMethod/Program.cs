using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int result = GetMin(a, b);
            result = GetMin(result, c);
            Console.WriteLine(result);
        }

        static private int GetMin(int a, int b)
        {
            int result = Math.Min(a, b);
            return result;
        }
    }
}

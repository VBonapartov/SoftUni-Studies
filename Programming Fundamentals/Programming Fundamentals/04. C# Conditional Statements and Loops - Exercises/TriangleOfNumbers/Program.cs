using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for(int i = 1; i <= n; i++)
            {
                StringBuilder output = new StringBuilder();
                for (int p = 1; p <= i; p++)
                {
                    output.AppendFormat($"{i} ");
                }
                Console.WriteLine(output);
            }
        }
    }
}

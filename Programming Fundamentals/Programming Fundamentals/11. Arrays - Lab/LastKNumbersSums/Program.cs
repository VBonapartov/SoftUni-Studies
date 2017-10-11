using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastKNumbersSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] sequence = new long[n];
            sequence[0] = 1;

            for(int i = 0; i < n; i++)
            {
                int firstNum = (i - k < 0) ? 0 : (i - k);
                for(int p = firstNum; p <= i - 1 && p >= 0; p++)
                {
                    sequence[i] += sequence[p];
                }
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

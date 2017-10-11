using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arrInt = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            bool found = false;
            for(int a = 0; a < arrInt.Length; a++)
            {
                for(int b = a + 1; b < arrInt.Length; b++)
                {
                    for(int c = 0; c < arrInt.Length; c++)
                    {
                        if(arrInt[a] + arrInt[b] == arrInt[c])
                        {
                            found = true;
                            Console.WriteLine($"{arrInt[a]} + {arrInt[b]} == {arrInt[c]}");
                            break;
                        }
                    }
                }
            }

            if(!found)
            {
                Console.WriteLine("No");
            }
        }
    }
}

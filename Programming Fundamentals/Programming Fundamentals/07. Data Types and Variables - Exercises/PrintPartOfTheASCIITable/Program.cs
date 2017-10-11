using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPartOfTheASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int charStartIdx = int.Parse(Console.ReadLine());
            int charEndIdx = int.Parse(Console.ReadLine());

            for(char start = (char)charStartIdx; start <= charEndIdx; start++)
            {
                Console.Write(start + " ");
            }
            Console.WriteLine();
        }
    }
}

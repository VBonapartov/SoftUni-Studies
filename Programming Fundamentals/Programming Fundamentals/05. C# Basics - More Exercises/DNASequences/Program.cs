using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNASequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());

            char[] nucleotide = new char[4];
            nucleotide[0] = 'A';
            nucleotide[1] = 'C';
            nucleotide[2] = 'G';
            nucleotide[3] = 'T';

            for (int d1 = 0; d1 < 4; d1++)
            {
                for (int d2 = 0; d2 < 4; d2++)
                {
                    for (int d3 = 0; d3 < 4; d3++)
                    {
                        char symbol = 'X';
                        if ((d1 + 1) + (d2 + 1) + (d3 + 1) >= sum)
                        {
                            symbol = 'O';
                        }

                        Console.Write($"{symbol}{nucleotide[d1]}{nucleotide[d2]}{nucleotide[d3]}{symbol} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strawberry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = 2 * n + 1;
            int cols = 2 * n + 3;
            
            for(int row = 0; row < rows; row++)
            {
                StringBuilder output = new StringBuilder();
                if (row < n / 2)
                {
                    string leftRightDashes = new string('-', row * 2);
                    string middleDashes = new string('-', (cols - 2 * leftRightDashes.Length - 3) / 2);

                    output.Append(leftRightDashes + "\\" + middleDashes + "|" + middleDashes + "/" + leftRightDashes);
                }
                else if(row >= n / 2 && row < n)
                {
                    string leftRightDashes = new string('-', n - ((2 * row + 1) - n));
                    string middleDots = new string('.', cols - 2 * leftRightDashes.Length - 2);

                    output.Append(leftRightDashes + "#" + middleDots + "#" + leftRightDashes);
                }
                else if(row >= n)
                {
                    string leftRightDashes = new string('-', row - n);
                    string middleDots = new string('.', cols - 2 *leftRightDashes.Length - 2);

                    output.Append(leftRightDashes + "#" + middleDots + "#" + leftRightDashes);
                }

                Console.WriteLine(output);
            }            
        }
    }
}

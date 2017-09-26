using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int middleRow = (int)Math.Ceiling(n / 2.0);
            for(int currentRow = 1; currentRow <= n; currentRow++)
            {
                StringBuilder output = new StringBuilder(n);
                if(currentRow < middleRow)
                {
                    string spacesLeftRight = new string(' ', currentRow - 1);
                    string spacesMiddle = new string(' ', n - 2 * spacesLeftRight.Length - 2);
                    output.AppendFormat($"{spacesLeftRight}x{spacesMiddle}x{spacesLeftRight}");
                }
                else if (currentRow == middleRow)
                {
                    string spaces = new string(' ', (n - 1) / 2);
                    output.AppendFormat($"{spaces}x{spaces}");
                }
                else
                {
                    string spacesLeftRight = new string(' ', n - currentRow);
                    string spacesMiddle = new string(' ', n - 2 * spacesLeftRight.Length - 2);
                    output.AppendFormat($"{spacesLeftRight}x{spacesMiddle}x{spacesLeftRight}");
                }
                Console.WriteLine(output);
            }
        }
    }
}

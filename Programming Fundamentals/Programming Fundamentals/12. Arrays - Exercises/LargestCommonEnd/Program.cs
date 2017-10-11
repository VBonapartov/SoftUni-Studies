using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStr1 = Console.ReadLine().Split(' ');
            string[] arrStr2 = Console.ReadLine().Split(' ');

            int minLength = Math.Min(arrStr1.Length, arrStr2.Length);

            int countEqualElementsStart = 0;
            for(int i = 0; i < minLength; i++)
            {
                if (arrStr1[i].Equals(arrStr2[i]))
                {
                    countEqualElementsStart++;
                }
                else
                {
                    break;
                }
            }

            int countEqualElementsEnd = 0;
            int diff = arrStr2.Length - arrStr1.Length;
            for (int i = arrStr1.Length - 1; i > 0; i--)
            {
                if (arrStr1[i].Equals(arrStr2[i + diff]))
                {
                    countEqualElementsEnd++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("{0}", (countEqualElementsStart >= countEqualElementsEnd) ? countEqualElementsStart : countEqualElementsEnd);
        }
    }
}

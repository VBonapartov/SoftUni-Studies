using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            List<int> result = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(string.Join(", ", result));
        }

        static private List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> result = new List<int>(){};
            for(int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        static private bool IsPrime(int n)
        {
            bool result = (n > 1);
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

    }
}

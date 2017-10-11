using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int result = GetNthFibonacciNumber(number);
            Console.WriteLine(result);
        }

        static private int GetNthFibonacciNumber(int number)
        {
            int firstNum = 1;
            int secondNum = 1;

            if (number == 0 || number == 1)
                return 1;

            int result = 0;
            for(int i = 2; i <= number; i++)
            {
                result = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = result;
            }

            return result;
        }
    }
}

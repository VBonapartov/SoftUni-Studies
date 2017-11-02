using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine().Trim();
            string number2 = Console.ReadLine().Trim();

            string result = SumBigNumbers(number1, number2);
            Console.WriteLine(result);
        }

        private static string SumBigNumbers(string number1, string number2)
        {
            int maxLenNum = Math.Max(number1.Length, number2.Length);

            number1 = number1.PadLeft(maxLenNum, '0');
            number2 = number2.PadLeft(maxLenNum, '0');            

            int carry = 0;
            StringBuilder result = new StringBuilder();
            for(int i = maxLenNum - 1; i >= 0; i--)
            {
                int sumLastDigits = Convert.ToInt32(number1[i].ToString()) + Convert.ToInt32(number2[i].ToString()) + carry;
                carry = 0;
                result.Append(sumLastDigits % 10);

                if (sumLastDigits > 9)
                    carry = 1;
            }

            if(carry == 1)
                result.Append(carry);

            return new string(result.ToString().TrimEnd('0').Reverse().ToArray());
        }
    }
}

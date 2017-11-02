using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine().Trim();
            int number2 = int.Parse(Console.ReadLine());        

            string result = MultiplyBigNumber(number1, number2);
            Console.WriteLine(result);
        }

        private static string MultiplyBigNumber(string number1, int multiply)
        {
            if (multiply == 0)
                return "0";

            int carry = 0;
            StringBuilder result = new StringBuilder();
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int total = Convert.ToInt32(number1[i].ToString()) * multiply + carry;
                carry = 0;
                result.Append(total % 10);
                
                if (total > 9)
                    carry = total / 10;
            }

            if (carry > 0)
                result.Append(carry);

            return new string(result.ToString().TrimEnd('0').Reverse().ToArray());
        }
    }
}

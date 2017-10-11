using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningCoins_Broken
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string decrypted = string.Empty;
            float totalValue = 0.00f;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int digit1 = number / 100;
                int digit2 = (number % 100) / 10;
                int digit3 = number % 10;
                int twoDigitNumber = Convert.ToInt32(digit1.ToString() + digit3.ToString());

                int ASCIIcode = 0;              
                if (i % 2 == 0)
                {
                    ASCIIcode = twoDigitNumber + digit2;                    
                }
                else
                {
                    ASCIIcode = twoDigitNumber - digit2;
                }

                if ((ASCIIcode >= 65 && ASCIIcode <= 90)
                    || (ASCIIcode >= 97 && ASCIIcode <= 122))
                {
                    decrypted += (char)ASCIIcode;
                }

                totalValue += (digit1 + digit2 + digit3) / (float)n;
            }

            Console.WriteLine("Message: {0}", decrypted);
            Console.WriteLine("Value: {0:F7}", totalValue);
        }
    }
}

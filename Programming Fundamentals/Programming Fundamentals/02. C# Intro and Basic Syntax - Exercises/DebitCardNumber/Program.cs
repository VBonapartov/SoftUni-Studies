using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebitCardNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int number4 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{number1:D4} {number2:D4} {number3:D4} {number4:D4}");

            //string number1ToString = number1.ToString().PadLeft(4, '0');
            //string number2ToString = number2.ToString().PadLeft(4, '0');
            //string number3ToString = number3.ToString().PadLeft(4, '0');
            //string number4ToString = number4.ToString().PadLeft(4, '0');

            //Console.WriteLine($"{number1ToString} {number2ToString} {number3ToString} {number4ToString}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            uint price1 = uint.Parse(Console.ReadLine());

            byte priceSByte = 0;
            uint priceInt = 0;
            if (price1 >= byte.MinValue && price1 <= byte.MaxValue)
            {
                priceSByte = Convert.ToByte(price1);
                priceInt = uint.Parse(Console.ReadLine());
            }
            else
            {
                priceSByte = byte.Parse(Console.ReadLine());
                priceInt = price1;
            }

            long totalPrice = priceSByte * 4L + priceInt * 10L;
            Console.WriteLine(totalPrice);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            byte capacity = 255;
            for (int i = 1; i <= n; i++)
            {
                int quantitiesOfWater = int.Parse(Console.ReadLine());

                if(capacity >= quantitiesOfWater)
                {
                    capacity -= (byte)quantitiesOfWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine($"{255 - capacity}");
        }
    }
}

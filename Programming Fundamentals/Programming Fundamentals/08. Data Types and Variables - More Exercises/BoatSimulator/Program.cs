using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int firstBoatTiles = 0;
            int secondBoatTiles = 0;
            for (int i = 1; i <= n; i++)
            {
                string inputStr = Console.ReadLine();
                
                if(inputStr.Equals("UPGRADE"))
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat + 3);

                    continue;
                }

                if(i % 2 == 0)
                {
                    secondBoatTiles += inputStr.Length;
                }
                else
                {
                    firstBoatTiles += inputStr.Length;
                }

                if (firstBoatTiles >= 50 || secondBoatTiles >= 50)
                    break;
            }

            Console.WriteLine("{0}", (firstBoatTiles > secondBoatTiles) ? firstBoat : secondBoat);
        }
    }
}

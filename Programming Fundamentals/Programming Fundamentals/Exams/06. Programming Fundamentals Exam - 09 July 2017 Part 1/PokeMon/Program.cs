using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int originalPower = pokePower;
            int countTargets = 0;
            while(pokePower >= distance)
            {
                countTargets++;
                pokePower -= distance;

                if(pokePower == (0.5 * originalPower))
                {
                    if (exhaustionFactor > 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(countTargets);
        }
    }
}

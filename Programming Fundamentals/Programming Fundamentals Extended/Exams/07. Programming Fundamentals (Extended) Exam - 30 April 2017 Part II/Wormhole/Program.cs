using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormhole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] wormholes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int countSteps = 0;
            int currentIndex = 0;
            while(currentIndex < wormholes.Length)
            {
                if(wormholes[currentIndex] == 0)
                {
                    currentIndex++;
                    countSteps++;
                }
                else
                {
                    int target = wormholes[currentIndex];
                    wormholes[currentIndex] = 0;
                    currentIndex = target;
                }
            }

            Console.WriteLine(countSteps);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> plane = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int startingPosition = int.Parse(Console.ReadLine());

            int initialDamage = 1;
            int currentPosition = startingPosition;
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Supernova"))
            {
                string[] commandArgs = input.Split(' ');

                switch(commandArgs[0])
                {
                    case "left":
                        Left(plane, ref currentPosition, Convert.ToInt32(commandArgs[1]), ref initialDamage);
                        break;

                    case "right":
                        Right(plane, ref currentPosition, Convert.ToInt32(commandArgs[1]), ref initialDamage);
                        break;
                }
            }

            PrintPlane(plane);
        }

        private static void Left(List<int> plane, ref int currentPosition, int step, ref int initialDamage)
        {
            while(step > 0)
            {
                currentPosition--;
                if(currentPosition < 0)
                {
                    currentPosition = plane.Count - 1;
                    initialDamage++;
                }

                plane[currentPosition] -= initialDamage;
                step--;
            }
        }

        private static void Right(List<int> plane, ref int currentPosition, int step, ref int initialDamage)
        {
            while (step > 0)
            {
                currentPosition++;
                if (currentPosition > plane.Count - 1)
                {
                    currentPosition = 0;
                    initialDamage++;
                }

                plane[currentPosition] -= initialDamage;
                step--;
            }
        }

        private static void PrintPlane(List<int> plane)
        {
            Console.WriteLine(string.Join(" ", plane));
        }
    }
}

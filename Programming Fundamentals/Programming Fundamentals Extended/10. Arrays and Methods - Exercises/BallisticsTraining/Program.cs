using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticsTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            string[] commands = Console.ReadLine().Split(' ');

            string currentCommand = string.Empty;
            long coordinateX = 0;
            long coordinateY = 0;
            for (int i = 0; i < commands.GetLength(0); i++)
            {
                if ((i & 1) != 0)
                {
                    switch (currentCommand)
                    {
                        case "up":
                            coordinateY += Convert.ToInt32(commands[i]);
                            break;
                        case "down":
                            coordinateY -= Convert.ToInt32(commands[i]);
                            break;
                        case "left":
                            coordinateX -= Convert.ToInt32(commands[i]);
                            break;
                        case "right":
                            coordinateX += Convert.ToInt32(commands[i]);
                            break;
                    }
                }
                else
                {
                    currentCommand = commands[i];
                }
            }

            Console.WriteLine($"firing at [{coordinateX}, {coordinateY}]");
            if (coordinates[0] == coordinateX && coordinates[1] == coordinateY)
            {                
                Console.WriteLine("got 'em!");
            }
            else
            {
                Console.WriteLine("better luck next time...");
            }

        }
    }
}

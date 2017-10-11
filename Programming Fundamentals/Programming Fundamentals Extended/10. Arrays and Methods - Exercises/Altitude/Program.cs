using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altitude
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(' ');

            long initialAltitude = Convert.ToInt64(commands[0]);

            string currentCommand = string.Empty;
            for(int i = 1; i < commands.GetLength(0); i++)
            {
                if((i & 1) == 0)
                {
                    switch(currentCommand)
                    {
                        case "up":
                            initialAltitude += Convert.ToInt32(commands[i]);
                            break;
                        case "down":
                            initialAltitude -= Convert.ToInt32(commands[i]);
                            break;
                    }
                }
                else
                {
                    currentCommand = commands[i];
                }

                if (initialAltitude <= 0)
                    break;
            }

            if (initialAltitude <= 0)
            {
                Console.WriteLine("crashed");
            }
            else
            {
                Console.WriteLine($"got through safely. current altitude: {initialAltitude}m");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            List<int> ladybugIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            ladybugIndexes = ladybugIndexes.Where(i => i < fieldSize).ToList();

            List<int> field = new List<int>();
            for (int i = 0; i < fieldSize; i++)
            {
                field.Add(0);
                if (ladybugIndexes.Contains(i))
                {
                    field[i] = 1;
                }
            }

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string[] commands = input.Split(' ');
                int currentPos = Convert.ToInt32(commands[0]);
                string command = commands[1];
                int step = Convert.ToInt32(commands[2]);

                if (0 > currentPos || currentPos >= field.Count)
                    continue;

                if (field[currentPos] == 0)
                    continue;

                field = FlyLadybug(field, currentPos, step, command);
            }

            PrintField(field);
        }

        private static List<int> FlyLadybug(List<int> field, int currentPos, int step, string command)
        {
            field[currentPos] = 0;
            int maxFieldIndex = field.Count - 1;

            if(command.Equals("right"))
            {
                long nextPos = currentPos + step;
                while((0 <= nextPos && nextPos <= maxFieldIndex))
                {
                    if(field[(int)nextPos] == 1)
                    {
                        nextPos += step;
                    }
                    else
                    {
                        field[(int)nextPos] = 1;
                        break;
                    }                    
                }                
            }
            else if(command.Equals("left"))
            {
                long nextPos = currentPos - step;
                while ((0 <= nextPos && nextPos <= maxFieldIndex))
                {
                    if (field[(int)nextPos] == 1)
                    {
                        nextPos -= step;
                    }
                    else
                    {
                        field[(int)nextPos] = 1;
                        break;
                    }
                }
            }

            return field;
        }

        private static void PrintField(List<int> field)
        {
            Console.WriteLine(string.Join(" ", field));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> command = Console.ReadLine().Trim().Split(' ').ToList();
            int energy = int.Parse(Console.ReadLine());

            int currentIndex = 0;
            bool isDeadFromBomb = false;

            while (energy > 0)
            {
                isDeadFromBomb = false;
                string[] currentCommand = command[currentIndex].Split('|');
                string action = currentCommand[0];

                if (action.Equals("RabbitHole"))
                {
                    Console.WriteLine("You have 5 years to save Kennedy!");
                    break;
                }

                int value = Convert.ToInt32(currentCommand[1]);

                switch (action)
                {
                    case "Left":
                        currentIndex = Math.Abs(currentIndex - value) % command.Count;
                        energy -= value;
                        break;

                    case "Right":
                        currentIndex = (currentIndex + value) % command.Count;
                        energy -= value;
                        break;

                    case "Bomb":
                        command.RemoveAt(currentIndex);
                        currentIndex = 0;
                        energy -= value;
                        isDeadFromBomb = true;
                        break;
                }

                if (!command[command.Count - 1].Equals("RabbitHole"))
                {
                    command.RemoveAt(command.Count - 1);
                }
                command.Add("Bomb|" + energy);


                if (energy <= 0 && isDeadFromBomb)
                {
                    Console.WriteLine("You are dead due to bomb explosion!");
                }
                else if (energy <= 0 && !isDeadFromBomb)
                {
                    Console.WriteLine("You are tired. You can't continue the mission.");
                }
            }
        }
    }
}

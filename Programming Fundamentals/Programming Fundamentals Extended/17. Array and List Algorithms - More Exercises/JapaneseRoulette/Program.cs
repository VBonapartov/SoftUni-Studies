using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cylinderOfTheRevolver = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            List<string> playersInfo = Console.ReadLine().Trim().Split(' ').ToList();

            bool gameOver = false;
            int currentPosition = 2;
            for(int i = 0; i < playersInfo.Count; i++)
            {
                string[] command = playersInfo[i].Split(',');
                int power = Convert.ToInt32(command[0]);
                string direction = command[1];

                switch(direction)
                {
                    case "Left":
                        currentPosition = (currentPosition + power) % cylinderOfTheRevolver.Count;

                        //while (power > 0)
                        //{
                        //    currentPosition++;
                        //    power--;
                        //    if (currentPosition > cylinderOfTheRevolver.Count - 1)
                        //        currentPosition = 0;
                        //}

                        break;
                    case "Right":
                        currentPosition = (currentPosition - power);
                        while(currentPosition < 0)
                            currentPosition += cylinderOfTheRevolver.Count;

                        //while (power > 0)
                        //{
                        //    currentPosition--;
                        //    power--;
                        //    if (currentPosition < 0)
                        //        currentPosition = cylinderOfTheRevolver.Count - 1;
                        //}

                        break;
                }
               
                if(cylinderOfTheRevolver[currentPosition] == 1)
                {
                    Console.WriteLine($"Game over! Player {i} is dead.");
                    gameOver = true;
                    break;
                }

                currentPosition--;
            }

            if(!gameOver)
            {
                Console.WriteLine("Everybody got lucky!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_ofNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPlayers = int.Parse(Console.ReadLine());

            string winnerName = string.Empty;
            int winnerPoints = int.MinValue;
            for(int i = 0; i < countOfPlayers; i++)
            {
                string name = Console.ReadLine();
                int score = int.Parse(Console.ReadLine());

                int result = CalculatePoints(score, name);

                if(result > winnerPoints)
                {
                    winnerPoints = result;
                    winnerName = name;
                }
            }

            Console.WriteLine($"The winner is {winnerName} - {winnerPoints} points");
        }

        private static int CalculatePoints(int score, string name)
        {
            int points = score;

            for(int i = 0; i < name.Length; i++)
            {
                int asciiCode = name[i];
                if(asciiCode % 2 == 0)
                {
                    points += asciiCode;
                }
                else
                {
                    points -= asciiCode;
                }
            }

            return points;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNewcomers = int.Parse(Console.ReadLine());

            int countStudentsInGryffindor = 0;
            int countStudentsInSlytherin = 0;
            int countStudentsInRavenclaw = 0;
            int countStudentsInHufflepuff = 0;
            for (int i = 0; i < numberOfNewcomers; i++)
            {
                string[] name = Console.ReadLine().Split(' ');
                string firstName = name[0];
                string secondName = name[1];

                int totalSum = sumsASCIICodes(firstName) + sumsASCIICodes(secondName);
                string house = GetHouse(totalSum);

                switch(house)
                {
                    case "Gryffindor":
                        countStudentsInGryffindor++;
                        break;

                    case "Slytherin":
                        countStudentsInSlytherin++;
                        break;

                    case "Ravenclaw":
                        countStudentsInRavenclaw++;
                        break;

                    case "Hufflepuff":
                        countStudentsInHufflepuff++;
                        break;
                }

                string facNumber = totalSum.ToString() + firstName[0].ToString() + secondName[0].ToString();
                Console.WriteLine($"{house} {facNumber}");
            }

            Console.WriteLine();
            Console.WriteLine($"Gryffindor: {countStudentsInGryffindor}");
            Console.WriteLine($"Slytherin: {countStudentsInSlytherin}");
            Console.WriteLine($"Ravenclaw: {countStudentsInRavenclaw}");
            Console.WriteLine($"Hufflepuff: {countStudentsInHufflepuff}");
        }

        private static int sumsASCIICodes(string str)
        {
            int asciiSum = 0;

            for(int i = 0; i < str.Length; i++)
            {
                asciiSum += str[i];
            }

            return asciiSum;
        }

        private static string GetHouse(int sum)
        {
            string house = string.Empty;
            int reminder = sum % 4;

            if(reminder == 0)
            {
                house = "Gryffindor";
            }
            else if (reminder == 1)
            {
                house = "Slytherin";
            }
            else if (reminder == 2)
            {
                house = "Ravenclaw";
            }
            else if (reminder == 3)
            {
                house = "Hufflepuff";
            }

            return house;
        }
    }
}

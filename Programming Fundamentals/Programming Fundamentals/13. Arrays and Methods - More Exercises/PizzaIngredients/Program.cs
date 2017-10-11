using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrString = Console.ReadLine().Split(' ');
            int searchedLength = int.Parse(Console.ReadLine());

            int numberOfIngredients = 0;
            StringBuilder ingradients = new StringBuilder();
            // string[] ingredients = arrString.Where(x => x.Length == searchedLength).ToArray();

            for (int i = 0; i < arrString.Length; i++)
            {
                if (numberOfIngredients == 10)
                    break;

                if(arrString[i].Length == searchedLength)
                {
                    numberOfIngredients++;
                    if (ingradients.Length > 0)
                    {
                        ingradients.Append(", ");
                    }
                    ingradients.Append(arrString[i]);

                    Console.WriteLine($"Adding {arrString[i]}.");
                }
            }

            Console.WriteLine($"Made pizza with total of {numberOfIngredients} ingredients.");
            Console.WriteLine("The ingredients are: " + ingradients + ".");
        }
    }
}

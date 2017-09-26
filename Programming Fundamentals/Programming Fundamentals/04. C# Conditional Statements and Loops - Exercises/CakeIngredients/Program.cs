using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            int numberOfIngredients = 0;
            StringBuilder output = new StringBuilder();
            while (!(input = Console.ReadLine()).Equals("Bake!"))
            {
                output.AppendFormat($"Adding ingredient {input}.\n");
                numberOfIngredients++;
            }

            Console.Write(output);
            Console.WriteLine($"Preparing cake with {numberOfIngredients} ingredients.");
        }
    }
}

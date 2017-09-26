using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseADrink2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantities = int.Parse(Console.ReadLine());

            string drink = string.Empty;
            decimal price = 0.00m;
            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    price = 0.70m;
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    price = 1.00m;
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    price = 1.70m;
                    break;
                default:
                    drink = "Tea";
                    price = 1.20m;
                    break;
            };

            Console.WriteLine($"The {profession} has to pay {quantities * price}.");
        }
    }
}

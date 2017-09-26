using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
                        
            string input = string.Empty;
            bool isOutOfMoney = false;

            double currentBalance = balance;
            StringBuilder output = new StringBuilder();
            while(!(input = Console.ReadLine()).Equals("Game Time"))
            {
                double price = 0.00;
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        output.AppendFormat("Not Found\n");
                        continue;
                }

                if(currentBalance >= price)
                {
                    output.AppendFormat($"Bought {input}\n");
                    currentBalance -= price;
                }
                else
                {
                    output.AppendFormat("Too Expensive\n");
                }
                
                if (currentBalance == 0)
                {
                    output.AppendFormat("Out of money!\n");
                    isOutOfMoney = true;
                }
            }

            Console.Write(output);

            if (!isOutOfMoney)
                Console.WriteLine($"Total spent: ${(balance - currentBalance):F2}. Remaining: ${currentBalance:F2}");
        }
    }
}

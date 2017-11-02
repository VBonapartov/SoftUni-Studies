using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> shopsInventory = new Dictionary<string, int>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("exam time"))
            {
                string[] command = input.Split(' ');

                switch(command[0])
                {
                    case "stock":
                        AddProductToShopInventory(shopsInventory, command); 
                        break;

                    case "buy":
                        BuyProductFromShop(shopsInventory, command);
                        break;
                }
            }

            foreach(KeyValuePair<string, int> product in shopsInventory)
            {
                if(product.Value > 0)
                    Console.WriteLine($"{product.Key} -> {product.Value}");
            }
        }

        static private void AddProductToShopInventory(Dictionary<string, int> shopsInventory, string[] productInfo)
        {
            string productName = productInfo[1];
            int productQuantity = Convert.ToInt32(productInfo[2]);

            if(shopsInventory.ContainsKey(productName))
            {
                shopsInventory[productName] += productQuantity;
            }
            else
            {
                shopsInventory.Add(productName, productQuantity);
            }
        }

        static private void BuyProductFromShop(Dictionary<string, int> shopsInventory, string[] productInfo)
        {
            string productName = productInfo[1];
            int productQuantity = Convert.ToInt32(productInfo[2]);

            if (shopsInventory.ContainsKey(productName))
            {
                if(shopsInventory[productName] == 0)
                {
                    Console.WriteLine($"{productName} out of stock");
                }
                else
                {
                    shopsInventory[productName] -= productQuantity;
                    shopsInventory[productName] = (shopsInventory[productName] < 0) ? 0 : shopsInventory[productName];
                }
            }
            else
            {
                Console.WriteLine($"{productName} doesn't exist");
            }
        }
    }
}

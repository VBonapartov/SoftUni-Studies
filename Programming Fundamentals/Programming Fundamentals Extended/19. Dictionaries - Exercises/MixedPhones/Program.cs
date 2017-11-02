using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedPhones
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, decimal> phoneBook = new SortedDictionary<string, decimal>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Over"))
            {
                string[] command = input.Split(' ');
                string firstElement = command[0];
                string secondElement = command[2];

                decimal phoneNumber = 0m;
                if (decimal.TryParse(firstElement, out phoneNumber))
                {
                    phoneBook.Add(secondElement, phoneNumber);
                }
                else
                {
                    decimal.TryParse(secondElement, out phoneNumber);
                    phoneBook.Add(firstElement, phoneNumber);
                }
            }

            foreach(KeyValuePair<string, decimal> item in phoneBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}

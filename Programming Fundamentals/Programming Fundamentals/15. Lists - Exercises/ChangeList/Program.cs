using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while(!input.Equals("Odd") && !input.Equals("Even"))
            {
                string[] commands = input.Split(' ');
                switch(commands[0])
                {
                    case "Delete":
                        Delete(listNumbers, Convert.ToInt32(commands[1]));
                        break;
                    case "Insert":
                        Insert(listNumbers, Convert.ToInt32(commands[1]), Convert.ToInt32(commands[2]));
                        break;
                }

                input = Console.ReadLine();
            }

            PrintList(listNumbers, input);
            
        }

        static private void Delete(List<int> numbers, int element)
        {
            numbers.RemoveAll(x => x == element);
        }

        static private void Insert(List<int> numbers, int element, int position)
        {
            numbers.Insert(position, element);
        }

        static private void PrintList(List<int> numbers, string numberType)
        {
            if (numberType.Equals("Odd"))
            {
                numbers = numbers.Where(x => x % 2 != 0).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                numbers = numbers.Where(x => x % 2 == 0).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}

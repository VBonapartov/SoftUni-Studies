using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int countExceptions = 0;
            while (countExceptions < 3)
            {
                // With StringSplitOptions.RemoveEmptyEntries option not work -> remove white spaces but for ex. Show with space is correct INPUT command!
                string[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }); ;
                try
                {
                    switch (input[0])
                    {
                        case "Replace":
                            ReplaceElement(numbers, input, ref countExceptions);
                            break;

                        case "Print":
                            PrintElements(numbers, input, ref countExceptions);
                            break;

                        case "Show":
                            ShowElement(numbers, input, ref countExceptions);
                            break;
                    }
                }
                catch (Exception)
                {
                    PrintError(input);
                    countExceptions++;
                }
            }
  
            PrintNumbers(numbers);
        }

        private static void ReplaceElement(int[] numbers, string[] input, ref int countExceptions)
        {
            int index = Convert.ToInt32(input[1]);
            int element = Convert.ToInt32(input[2]);

            numbers[index] = element;
        }

        private static void PrintElements(int[] numbers, string[] input, ref int countExceptions)
        {
            int startIndex = Convert.ToInt32(input[1]);
            int endIndex = Convert.ToInt32(input[2]);

            List<int> printNumbers = new List<int>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                printNumbers.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(", ", printNumbers));
        }

        private static void ShowElement(int[] numbers, string[] input, ref int countExceptions)
        {
            int index = Convert.ToInt32(input[1]);
            Console.WriteLine(numbers[index]);
        }

        private static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void PrintError(string[] input)
        {
            int check = 0;
            if (input.Length > 2)
            {
                if (int.TryParse(input[1], out check) &&
                    int.TryParse(input[2], out check))
                {
                    Console.WriteLine("The index does not exist!");
                }
                else
                {
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }
            else
            {
                if (int.TryParse(input[1], out check))
                {
                    Console.WriteLine("The index does not exist!");
                }
                else
                {
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }
        }
    }
}

namespace _03.DecimalToBinConverter
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(number);
            }
            else
            {
                Stack<int> stack = new Stack<int>();

                while (number > 0)
                {
                    int reminder = number % 2;
                    stack.Push(reminder);
                    number /= 2;
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }
                Console.WriteLine();
            }
        }
    }
}

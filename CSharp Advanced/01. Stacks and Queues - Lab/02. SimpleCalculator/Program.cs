namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] reminder = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(reminder.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string op = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (op.Equals("+"))
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else if (op.Equals("-"))
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}

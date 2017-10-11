using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int operand1 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int operand2 = int.Parse(Console.ReadLine());

            double result = 0.00;
            switch(operation)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
                case '*':
                    result = operand1 * operand2;
                    break;
                case '/':
                    result = operand1 / operand2;
                    break;
            }

            Console.WriteLine($"{operand1} {operation} {operand2} = {result}");
        }
    }
}

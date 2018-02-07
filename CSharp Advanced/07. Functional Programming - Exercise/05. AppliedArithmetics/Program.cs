namespace _05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("end"))
            {
                if (command.Equals("print"))
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    Func<double, double> mathOperation = CreateMathOperation(command);
                    numbers = numbers.Select(d => mathOperation(d)).ToList();
                }
            }
        }

        private static Func<double, double> CreateMathOperation(string command)
        {
            switch (command)
            {
                case "add":
                    return (double num) => { return num + 1; };

                case "subtract":
                    return (double num) => { return num - 1; };

                case "multiply":
                    return (double num) => { return num * 2.0; };

                default:
                    return null;
            }
        }
    }
}

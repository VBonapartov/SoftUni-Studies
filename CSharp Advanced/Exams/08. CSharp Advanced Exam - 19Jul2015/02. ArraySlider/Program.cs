namespace _02.ArraySlider
{
    using System;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        private static BigInteger[] array;

        static void Main(string[] args)
        {
            array = Console.ReadLine().Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            ExecuteCommands(array);
        }

        private static void ExecuteCommands(BigInteger[] array)
        {
            // start position
            int index = 0;

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("stop"))
            {
                string[] cmdArgs = input.Split(new []{ " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                int offset = int.Parse(cmdArgs[0]);
                string operation = cmdArgs[1];
                int operand = int.Parse(cmdArgs[2]);

                index += offset;
                index = index % array.Length;
                index += (index < 0) ? array.Length : 0;                

                switch (operation)
                {
                    case "*":
                        array[index] *= operand;
                        break;

                    case "/":
                        array[index] /= operand;
                        break;

                    case "+":
                        array[index] += operand;
                        break;

                    case "-":
                        array[index] -= operand;
                        array[index] = (array[index] < 0) ? 0 : array[index];
                        break;

                    case "&":
                        array[index] &= operand;
                        break;

                    case "|":
                        array[index] |= operand;
                        break;

                    case "^":
                        array[index] ^= operand;
                        break;
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }
    }
}

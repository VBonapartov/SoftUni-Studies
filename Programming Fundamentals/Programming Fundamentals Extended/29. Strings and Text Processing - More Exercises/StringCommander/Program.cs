using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCommander
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputStr = new StringBuilder(Console.ReadLine());
            ReadInput(inputStr);
            PrintString(inputStr);
        }

        private static void ReadInput(StringBuilder inputStr)
        {
            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("end"))
            {
                string[] tokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Left":
                        Left(inputStr, Convert.ToInt32(tokens[1]));
                        break;

                    case "Right":
                        Right(inputStr, Convert.ToInt32(tokens[1]));
                        break;

                    case "Insert":
                        Insert(inputStr, Convert.ToInt32(tokens[1]), tokens[2]);
                        break;

                    case "Delete":
                        Delete(inputStr, Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]));
                        break;
                }
            }
        }

        private static void Left(StringBuilder inputStr, int steps)
        {
            for(int i = 0; i < steps; i++)
            {
                string newString = inputStr.ToString().Substring(1) + inputStr[0];
                inputStr.Clear();
                inputStr.Append(newString);
            }
        }

        private static void Right(StringBuilder inputStr, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                string newString = inputStr[inputStr.Length - 1] + inputStr.ToString().Substring(0, inputStr.Length - 1);
                inputStr.Clear();
                inputStr.Append(newString);
            }
        }

        private static void Insert(StringBuilder inputStr, int index, string insString)
        {
            inputStr.Insert(index, insString);            
        }

        private static void Delete(StringBuilder inputStr, int startIndex, int endIndex)
        {
            inputStr.Remove(startIndex, endIndex - startIndex + 1);
        }

        private static void PrintString(StringBuilder inputStr)
        {
            Console.WriteLine(inputStr);
        }
    }
}

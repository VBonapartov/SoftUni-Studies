namespace _01.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<string> collection;

        static void Main(string[] args)
        {
            collection = Console.ReadLine()
                                .Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            ExecuteCommands();
        }

        private static void ExecuteCommands()
        {
            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("end"))
            {
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];

                switch(command)
                {
                    case "reverse":
                        Reverse(cmdArgs);
                        break;

                    case "sort":
                        Sort(cmdArgs);
                        break;

                    case "rollLeft":
                        RollLeft(cmdArgs);
                        break;

                    case "rollRight":
                        RollRight(cmdArgs);
                        break;
                }
            }

            PrintResult();
        }

        private static void Reverse(string[] cmdArgs)
        {
            int index;
            int count;
            
            if(!int.TryParse(cmdArgs[2], out index) || !int.TryParse(cmdArgs[4], out count) ||
                index < 0 || index > collection.Count - 1 || count < 0 || count + index > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> portion = collection.GetRange(index, count);
            portion.Reverse();

            collection.RemoveRange(index, count);
            collection.InsertRange(index, portion);
        }

        private static void Sort(string[] cmdArgs)
        {
            int index;
            int count;

            if (!int.TryParse(cmdArgs[2], out index) || !int.TryParse(cmdArgs[4], out count) ||
                index < 0 || index > collection.Count - 1 || count < 0 || count + index > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> sortedPortion = collection.GetRange(index, count).OrderBy(e => e).ToList();

            collection.RemoveRange(index, count);
            collection.InsertRange(index, sortedPortion);
        }

        private static void RollLeft(string[] cmdArgs)
        {
            int count;

            if (!int.TryParse(cmdArgs[1], out count) || count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            count = count % collection.Count;

            for(int i = 0; i < count; i++)
            {
                collection.Add(collection[0]);
                collection.RemoveAt(0);
            }
        }

        private static void RollRight(string[] cmdArgs)
        {
            int count;

            if (!int.TryParse(cmdArgs[1], out count) || count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            count = count % collection.Count;

            for (int i = 0; i < count; i++)
            {
                collection.Insert(0, collection[collection.Count - 1]);
                collection.RemoveAt(collection.Count - 1);
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine($"[{string.Join(", ", collection)}]");
        }
    }
}

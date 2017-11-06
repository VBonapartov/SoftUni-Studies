using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfStrings = Console.ReadLine().Split(' ').ToList();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("3:1"))
            {
                string[] commandArgs = input.Split(' ');

                if (commandArgs.Length != 3)
                    continue;

                listOfStrings = ExecuteCommand(listOfStrings, commandArgs);
            }

            PrintResult(listOfStrings);
        }

        private static List<string> ExecuteCommand(List<string> listOfStrings, string[] commandArgs)
        {
            string command = commandArgs[0];

            switch (command)
            {
                case "merge":
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    listOfStrings = Merge(listOfStrings, startIndex, endIndex);
                    break;

                case "divide":
                    int index = int.Parse(commandArgs[1]);
                    int partitions = int.Parse(commandArgs[2]);

                    listOfStrings = Divide(listOfStrings, index, partitions);
                    break;
            }

            return listOfStrings;
        }

        private static List<string> Merge(List<string> listOfStrings, int startIndex, int endIndex)
        {
            // Validate startIndex and endIndex
            startIndex = (startIndex < 0) ? 0 : startIndex;
            startIndex = (startIndex > listOfStrings.Count - 1) ? listOfStrings.Count - 1 : startIndex;

            endIndex = (endIndex < 0) ? 0 : endIndex;
            endIndex = (endIndex > listOfStrings.Count - 1) ? listOfStrings.Count - 1 : endIndex;

            // Merge all elements from the startIndex, till the endIndex 
            StringBuilder concatenateStrings = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                concatenateStrings.Append(listOfStrings[i]);
            }

            // Return list after merge command
            return CreateFinalList(listOfStrings, new List<string> { concatenateStrings.ToString() }, startIndex, endIndex);
        }

        private static List<string> Divide(List<string> listOfStrings, int index, int partitions)
        {
            // Check for valid index
            if(index < 0 || index > listOfStrings.Count - 1)
            {
                return listOfStrings;
            }

            // Return list after divide command
            return CreateFinalList(listOfStrings, GetSubstrings(listOfStrings, index, partitions), index, index);
        }

        // Divide the element at the given index, into several small substrings
        private static List<string> GetSubstrings(List<string> listOfStrings, int index, int partitions)
        {
            List<string> result = new List<string>();

            string item = listOfStrings[index];
            if (item.Length % partitions == 0)
            {
                int len = item.Length / partitions;
                for (int i = 0; i < partitions; i++)
                {
                    string part = item.Substring(0, len);
                    item = item.Substring(len);

                    result.Add(part);
                }
            }
            else
            {
                int len = item.Length / partitions;
                for (int i = 0; i < partitions - 1; i++)
                {
                    string part = item.Substring(0, len);
                    item = item.Substring(len);

                    result.Add(part);
                }
                result.Add(item);
            }

            return result;
        }

        private static List<string> CreateFinalList(List<string> listOfStrings, List<string> listOfMergeOrDivideElements, int startIndex, int endIndex)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < startIndex; i++)
            {
                result.Add(listOfStrings[i]);
            }

            result.AddRange(listOfMergeOrDivideElements);

            for (int i = endIndex + 1; i < listOfStrings.Count; i++)
            {
                result.Add(listOfStrings[i]);
            }

            return result;
        }

        // Print final result
        private static void PrintResult(List<string> listOfStrings)
        {
            Console.WriteLine(string.Join(" ", listOfStrings));
        }
    }
}

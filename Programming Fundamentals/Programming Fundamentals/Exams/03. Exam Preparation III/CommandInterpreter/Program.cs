using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = Console.ReadLine().Split(new string[] { " ", "\t", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string[] commandArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commandArgs[0];

                switch(command)
                {
                    case "reverse":
                        collection = Reverse(collection, Convert.ToInt32(commandArgs[2]), Convert.ToInt32(commandArgs[4]));
                        break;

                    case "sort":
                        collection = Sort(collection, Convert.ToInt32(commandArgs[2]), Convert.ToInt32(commandArgs[4]));
                        break;

                    case "rollLeft":
                        collection = RollLeft(collection, Convert.ToInt32(commandArgs[1]));
                        break;

                    case "rollRight":
                        collection = RollRight(collection, Convert.ToInt32(commandArgs[1]));
                        break;
                }
            }

            PrintCollection(collection);
        }

        private static List<string> Reverse(List<string> collection, int startIndex, int count)
        {
            if( 0 > startIndex || startIndex >= collection.Count || 
                0 > count || startIndex + count > collection.Count
              )
            {
                Console.WriteLine("Invalid input parameters.");
                return collection;
            }

            List<string> portion = collection.GetRange(startIndex, count);
            portion.Reverse();

            collection.RemoveRange(startIndex, count);
            collection.InsertRange(startIndex, portion);

            return collection;
        }

        private static List<string> Sort(List<string> collection, int startIndex, int count)
        {
            if (0 > startIndex || startIndex >= collection.Count ||
                0 > count || startIndex + count > collection.Count
              )
            {
                Console.WriteLine("Invalid input parameters.");
                return collection;
            }

            List<string> sortedPortion = collection.GetRange(startIndex, count).OrderBy(e => e).ToList();

            collection.RemoveRange(startIndex, count);
            collection.InsertRange(startIndex, sortedPortion);

            return collection;
        }

        private static List<string> RollLeft(List<string> collection, int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return collection;
            }

            count %= collection.Count;
            while(count > 0)
            {
                string firstElement = collection[0];
                collection.RemoveAt(0);
                collection.Add(firstElement);

                count--;
            }

            return collection;
        }

        private static List<string> RollRight(List<string> collection, int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return collection;
            }

            collection.Reverse();
            count %= collection.Count;
            while (count > 0)
            {
                string firstElement = collection[0];
                collection.RemoveAt(0);
                collection.Add(firstElement);

                count--;
            }
            collection.Reverse();

            return collection;
        }

        private static void PrintCollection(List<string> collection)
        {
            Console.WriteLine($"[{string.Join(", ", collection)}]");
        }
    }
}

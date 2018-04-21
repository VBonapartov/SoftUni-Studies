namespace _09._LinkedListTraversal
{
    using System;

    public class Program
    {
        private static LinkedList<int> myLinkedList;

        public static void Main(string[] args)
        {
            myLinkedList = new LinkedList<int>();

            Run();
            PrintResult();
        }

        private static void Run()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int number = int.Parse(cmdArgs[1]);

                try
                {
                    switch (command)
                    {
                        case "Add":
                            myLinkedList.Add(number);
                            break;

                        case "Remove":
                            myLinkedList.Remove(number);
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(myLinkedList.Count);
            Console.WriteLine(string.Join(" ", myLinkedList));
        }
    }
}

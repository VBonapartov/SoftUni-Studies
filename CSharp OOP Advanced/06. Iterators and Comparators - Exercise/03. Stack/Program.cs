namespace _03._Stack
{
    using System;
    using System.Linq;

    public class Program
    {
        private static Stack<int> myStack;

        public static void Main(string[] args)
        {
            InitializeCollection();
            ReadAndExecutesCommands();

            PrintStack();
            PrintStack();
        }

        private static void InitializeCollection()
        {
            myStack = new Stack<int>();
        }

        private static void ReadAndExecutesCommands()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];

                switch (command)
                {
                    case "Push":
                        foreach (int num in cmdArgs.Skip(1).Select(int.Parse))
                        {
                            myStack.Push(num);
                        }

                        break;

                    case "Pop":
                        try
                        {
                            myStack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }

                        break;

                    default:
                        break;
                }
            }
        }

        private static void PrintStack()
        {
            foreach (int element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}

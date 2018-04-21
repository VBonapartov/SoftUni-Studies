namespace _08._CustomListSorter
{
    using System;

    public class Program
    {
        private static MyList<string> myList = new MyList<string>();

        public static void Main(string[] args)
        {
            ReadCommands();
        }

        private static void ReadCommands()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];

                switch (command)
                {
                    case "Add":
                        myList.Add(cmdArgs[1]);
                        break;

                    case "Remove":
                        myList.Remove(int.Parse(cmdArgs[1]));
                        break;

                    case "Contains":
                        Console.WriteLine(myList.Contains(cmdArgs[1]) ? "True" : "False");
                        break;

                    case "Swap":
                        myList.Swap(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                        break;

                    case "Greater":
                        Console.WriteLine(myList.CountGreaterThan(cmdArgs[1]));
                        break;

                    case "Max":
                        Console.WriteLine(myList.Max());
                        break;

                    case "Min":
                        Console.WriteLine(myList.Min());
                        break;

                    case "Sort":
                        myList = Sorter.Sort(myList);
                        break;

                    case "Print":
                        Print();
                        break;
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(Environment.NewLine, myList));
        }
    }
}

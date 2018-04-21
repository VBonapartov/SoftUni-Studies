namespace _02._Collection
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static ListyIterator<string> collection;

        public static void Main(string[] args)
        {
            InitializeCollection();
            string result = ReadAndExecutesCommands();
            PrintResult(result);
        }

        private static void InitializeCollection()
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');

            // There will always be only 1 Create command and it will always be the first command passed.
            if (cmdArgs.Length > 1)
            {
                collection = new ListyIterator<string>(cmdArgs.Skip(1));
            }
            else
            {
                collection = new ListyIterator<string>();
            }
        }

        private static string ReadAndExecutesCommands()
        {
            StringBuilder sb = new StringBuilder();

            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("END"))
            {
                try
                {
                    switch (command)
                    {
                        case "Move":
                            sb.AppendLine(collection.Move().ToString());
                            break;

                        case "HasNext":
                            sb.AppendLine(collection.HasNext().ToString());
                            break;

                        case "Print":
                            sb.AppendLine(collection.Print());
                            break;

                        case "PrintAll":
                            foreach (string element in collection)
                            {
                                sb.Append($"{element} ");
                            }

                            sb.Remove(sb.Length - 1, 1).AppendLine();
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    sb.AppendLine(ae.Message);
                }
            }

            return sb.ToString().Trim();
        }

        private static void PrintResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}

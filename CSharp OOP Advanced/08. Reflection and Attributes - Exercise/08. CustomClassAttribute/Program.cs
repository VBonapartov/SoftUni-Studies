namespace _08._CustomClassAttribute
{
    using System;
    using System.Linq;

    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            InfoAttribute attr = (InfoAttribute)typeof(Program).GetCustomAttributes(false).First();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                PrintInfo(attr, input);
            }
        }

        private static void PrintInfo(InfoAttribute attr, string attrField)
        {
            switch (attrField)
            {
                case "Author":
                    Console.WriteLine($"Author: {attr.Author}");
                    break;

                case "Revision":
                    Console.WriteLine($"Revision: {attr.Revision}");
                    break;

                case "Description":
                    Console.WriteLine($"Class description: {attr.Description}");
                    break;

                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                    break;

                default:
                    break;
            }
        }
    }
}

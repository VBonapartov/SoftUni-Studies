namespace _06._CustomEnumAttribute
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            GetDescription(command);
        }

        private static void GetDescription(string command)
        {
            Type type = command.Equals("Rank") ? typeof(CardRank) : typeof(CardSuit);
            object[] attrs = type.GetCustomAttributes(false);

            foreach (TypeAttribute attr in attrs)
            {
                Console.WriteLine(attr);
            }
        }
    }
}

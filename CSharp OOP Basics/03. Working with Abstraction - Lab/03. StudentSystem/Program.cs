namespace _03._StudentSystem
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            StudentSystem studentSystem = new StudentSystem();
            string command = string.Empty;

            while (!(command = Console.ReadLine()).Equals("Exit"))
            {
                studentSystem.ParseCommand(command, Console.WriteLine);
            }
        }
    }
}

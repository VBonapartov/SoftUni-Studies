namespace _03.Snowflake
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            int coreLength = 0;
            bool isValid = IsValid(out coreLength);

            if (isValid)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(coreLength);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

        private static bool IsValid(out int coreLength)
        {
            coreLength = 0;

            string surfacePattern = @"^([^a-zA-Z\d]+)$";
            string mantlePattern = @"^([\d_]+)$";
            string surfMantleCorePattern = @"^([^a-zA-Z\d]+)([\d_]+)([a-zA-Z]+)([\d_]+)([^a-zA-Z\d]+)$";

            string surface = Console.ReadLine();
            if (!Regex.IsMatch(surface, surfacePattern))
            {
                return false;
            }

            string mantle = Console.ReadLine();
            if (!Regex.IsMatch(mantle, mantlePattern))
            {
                return false;
            }

            string surfMantleCore = Console.ReadLine();
            Match match = Regex.Match(surfMantleCore, surfMantleCorePattern);
            if (!match.Success)
            {
                return false;
            }

            coreLength = match.Groups[3].Value.Length;

            mantle = Console.ReadLine();
            if (!Regex.IsMatch(mantle, mantlePattern))
            {
                return false;
            }

            surface = Console.ReadLine();
            if (!Regex.IsMatch(surface, surfacePattern))
            {
                return false;
            }

            return true;
        }
    }
}

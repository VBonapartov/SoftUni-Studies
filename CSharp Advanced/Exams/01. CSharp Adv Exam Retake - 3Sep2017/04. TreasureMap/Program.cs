namespace _04.TreasureMap
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        private static List<string> allInstructions = new List<string>();

        static void Main(string[] args)
        {
            ReadAllInstructions();
            ParseInstructions();
        }

        private static void ReadAllInstructions()
        {
            int numberOfInstructions = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfInstructions; i++)
            {
                allInstructions.Add(Console.ReadLine());
            }
        }

        private static void ParseInstructions()
        {   
            for (int i = 0; i < allInstructions.Count; i++)
            {                
                List<string[]> validInstructions = GetValidInstructions(allInstructions[i]);

                if (validInstructions.Count == 0)
                {
                    continue;
                }

                int indexOfInstruction = validInstructions.Count / 2;

                string[] instructionDetails = validInstructions[indexOfInstruction];

                string streetName = instructionDetails[0];
                string streetNumber = instructionDetails[1];
                string password = instructionDetails[2];

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }

        private static List<string[]> GetValidInstructions(string instructionsStr)
        {
            List<string[]> validInstructions = new List<string[]>();

            // get all valid instructions - “#{instruction pattern}!” or “!{instruction pattern}#”
            MatchCollection matches = Regex.Matches(instructionsStr, @"\![^\!\#]{13,}?\#|\#[^\!\#]{13,}?\!");

            if (matches.Count == 0)
            {
                return validInstructions;
            }

            foreach (Match match in matches)
            {
                MatchCollection address = Regex.Matches(match.Value, @"[^a-zA-z0-9](?<streetName>[a-zA-z]{4})[^a-zA-z0-9]");
                
                MatchCollection pairNumPass = Regex.Matches(match.Value, @"[^\d](?<streetNumber>\d{3})-(?<password>\d{6}|\d{4})[^\d]");
                
                if (address.Count != 0 && pairNumPass.Count != 0)
                {
                    string streetName = address[0].Groups["streetName"].Value;
                    string streetNumber = pairNumPass[pairNumPass.Count - 1].Groups["streetNumber"].Value;
                    string password = pairNumPass[pairNumPass.Count - 1].Groups["password"].Value;

                    validInstructions.Add(new string[3] { streetName, streetNumber, password });
                }
            }

            return validInstructions;
        }
    }
}

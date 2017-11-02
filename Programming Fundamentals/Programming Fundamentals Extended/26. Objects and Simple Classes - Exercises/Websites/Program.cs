using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websites
{
    class Website
    {
        public string Host { get; set; }
        public string Domain { get; set; }
        public List<string> Queries { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Website> websites = ReadInputSequence();
            PrintWebsites(websites);
        }

        private static List<Website> ReadInputSequence()
        {
            List<Website> websites = new List<Website>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                websites.Add(DecodeInputLine(input));
            }

            return websites;
        }

        private static Website DecodeInputLine(string input)
        {
            string[] command = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            Website website = new Website
            {
                Host = command[0],
                Domain = command[1],
                Queries = new List<string> { }
            };

            if(command.Length == 3)
            {
                website.Queries = command[2].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return website;
        }

        private static void PrintWebsites(List<Website> websites)
        {            
            foreach(Website website in websites)
            {
                StringBuilder output = new StringBuilder();
                output.Append($"https://www.{website.Host}.{website.Domain}");

                if (website.Queries.Count > 0)
                {                    
                    List<string> queries = website.Queries.Select(s => "[" + s + "]").ToList();
                    output.Append("/query?=" + string.Join("&", queries));
                }

                Console.WriteLine(output);
            }            
        }
    }
}

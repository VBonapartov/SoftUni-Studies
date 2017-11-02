using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> emails = GetValidEmails();
            PrintEmails(emails);
        }

        private static Dictionary<string, HashSet<string>> GetValidEmails()
        {
            Dictionary<string, HashSet<string>> emails = new Dictionary<string, HashSet<string>>();

            string pattern = @"^(?<username>[A-Za-z]{5,})@(?<domain>[a-z]{3,}(?:\.com|\.bg|\.org))$";
            int numberOfEmails = int.Parse(Console.ReadLine());
            for(int i = 1; i <= numberOfEmails; i++)
            {
                string email = Console.ReadLine();

                Match emailMatch = Regex.Match(email, pattern);
                if(emailMatch.Success)
                {
                    string username = emailMatch.Groups["username"].Value;
                    string domain = emailMatch.Groups["domain"].Value;

                    if(emails.ContainsKey(domain))
                    {
                       emails[domain].Add(username);                    
                    }
                    else
                    {
                        emails.Add(domain, new HashSet<string> { username });
                    }
                }
            }

            return emails;
        }

        private static void PrintEmails(Dictionary<string, HashSet<string>> emails)
        {
            emails = emails
                        .OrderByDescending(e => e.Value.Count)
                        .ToDictionary(e => e.Key, e => e.Value);

            foreach (KeyValuePair<string, HashSet<string>> email in emails)
            {
                Console.WriteLine($"{email.Key}:");

                foreach (string username in email.Value)
                {
                    Console.WriteLine($"### {username}");
                }
            }
        }
    }
}

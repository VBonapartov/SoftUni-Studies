using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            int currentLine = 0;
            string currentContact = string.Empty;

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("stop"))
            {
                currentLine++;

                if (currentLine % 2 != 0)
                {
                    currentContact = input;
                }
                else
                {
                    string domain = input.Substring(input.Length - 2);
                    if (domain.Equals("us") || domain.Equals("uk"))
                    {
                        continue;
                    }

                    if (contacts.ContainsKey(currentContact))
                    {
                        contacts[currentContact] = input;
                    }
                    else
                    {
                        contacts.Add(currentContact, input);
                    }
                }                
            }

            PrintContacts(contacts);
        }

        static private void PrintContacts(Dictionary<string, string> contacts)
        {
            foreach (KeyValuePair<string, string> contact in contacts)
            {
                Console.WriteLine($"{contact.Key} -> {contact.Value}");
            }
        }
    }
}

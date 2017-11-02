using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("END"))
            {
                string[] info = input.Split(' ');

                switch(info[0])
                {
                    case "A":
                        AddContact(phonebook, info);
                        break;
                    case "S":
                        SearcheContact(phonebook, info);
                        break;
                }
            }  
        }

        static private void AddContact(Dictionary<string, string> phonebook, string[] info)
        {
            if(phonebook.ContainsKey(info[1]))
            {
                phonebook[info[1]] = info[2];
            }
            else
            {
                phonebook.Add(info[1], info[2]);
            }
        }

        static private void SearcheContact(Dictionary<string, string> phonebook, string[] info)
        {
            if (phonebook.ContainsKey(info[1]))
            {
                Console.WriteLine($"{info[1]} -> {phonebook[info[1]]}");
            }
            else
            {
                Console.WriteLine($"Contact {info[1]} does not exist.");
            }
        }
    }
}

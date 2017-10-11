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
            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] names = Console.ReadLine().Split(' ');

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("done"))
            {
                Console.WriteLine($"{input} -> {GetPhoneNumberByName(phoneNumbers, names, input)}");
            }

        }

        static private string GetPhoneNumberByName(string[] phones, string[] names, string name)
        {
            int index = 0;
            for(int i = 0; i < names.GetLength(0); i++)
            {
                if(name.Equals(names[i]))
                {
                    index = i;
                    break;
                }
            }

            return phones[index];
        }
    }
}

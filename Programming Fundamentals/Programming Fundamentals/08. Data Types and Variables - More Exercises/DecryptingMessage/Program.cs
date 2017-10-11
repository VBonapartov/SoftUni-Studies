using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            StringBuilder message = new StringBuilder();
            for(int i = 1; i<= n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                char newChar = (char)(letter + key);
                message.Append(newChar);
            }

            Console.WriteLine(message);
        }
    }
}

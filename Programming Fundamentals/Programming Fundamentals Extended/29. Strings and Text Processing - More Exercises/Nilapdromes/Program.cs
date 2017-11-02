using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilapdromes
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput();
        }

        private static void ReadInput()
        {   
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string border = string.Empty;
                string core = string.Empty;

                if (IsNilapdrome(input, out border, out core))
                {
                    Console.WriteLine(core + border + core);
                }
            }
        }

        private static bool IsNilapdrome(string input, out string border, out string core)
        {
            border = string.Empty;
            core = string.Empty;

            int inputLen = input.Length;
            if (inputLen < 3)
                return false;

            if(inputLen == 3)
            {
                if (!input[0].Equals(input[2]))
                {
                    return false;
                }
                else
                {
                    border = input[0].ToString();
                    core = input[1].ToString();
                    return true;
                }
            }

            if(inputLen == 4)
            {
                if (!input[0].Equals(input[3]))
                {
                    return false;
                }
                else if (input.Substring(0, 2).Equals(input.Substring(2, 2)))
                {

                    return false;
                }
                else
                {
                    border = input[0].ToString();
                    core = input.Substring(1, 2);
                    return true;
                }
            }

            // more then 4 symbols
            int middle = input.Length / 2;
            for(int i = 0; i < middle; i++)
            {
                string firstPart = input.Substring(0, i + 1);
                string lastPart = input.Substring(input.Length - 1 - i);

                if(firstPart.Equals(lastPart))
                {
                    border = firstPart;
                    core = input.Substring(i + 1, input.Length - 2 * border.Length);
                }
            }

            if(border.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

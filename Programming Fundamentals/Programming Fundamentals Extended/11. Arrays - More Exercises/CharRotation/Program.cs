using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            StringBuilder output = new StringBuilder(inputString.Length);
            for(int i = 0; i < arrInt.GetLength(0); i++)
            {
                if (arrInt[i] % 2 == 0)
                {
                    output.Append((char)(Convert.ToChar(inputString[i]) - arrInt[i]));
                }
                else
                {
                    output.Append((char)(Convert.ToChar(inputString[i]) + arrInt[i]));
                }
            }

            Console.WriteLine(output);
        }
    }
}

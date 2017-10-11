using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableInHexFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexNumber = Console.ReadLine();

            int decNumber = Convert.ToInt32(hexNumber, 16);
            Console.WriteLine(decNumber);
        }
    }
}

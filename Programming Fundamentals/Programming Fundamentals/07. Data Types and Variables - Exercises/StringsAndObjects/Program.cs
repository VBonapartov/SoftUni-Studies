using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string variable1 = "Hello";
            string variable2 = "World";
            object variable3 = variable1 + " " + variable2;
            string variable4 = (string)variable3;

            Console.WriteLine(variable4);
        }
    }
}

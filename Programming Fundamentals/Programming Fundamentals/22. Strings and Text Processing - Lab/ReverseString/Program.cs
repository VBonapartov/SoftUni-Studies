using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = Console.ReadLine().ToCharArray();

            Array.Reverse(arr);
            Console.WriteLine(arr);
        }
    }
}

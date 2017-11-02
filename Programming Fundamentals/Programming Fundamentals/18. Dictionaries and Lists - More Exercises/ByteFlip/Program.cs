using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bytes = Console.ReadLine().Trim().Split(' ').ToList();

            bytes = bytes.Where(x => x.Length == 2).ToList();
            bytes = bytes.Select(x => new string(x.Reverse().ToArray())).ToList();
            bytes.Reverse();

            List<char> ascii = bytes.Select(x => (char)Convert.ToInt32(x, 16)).ToList();
            Console.WriteLine($"{string.Join("", ascii)}");
        }
    }
}

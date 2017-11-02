using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecryption
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrOfInt1 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int[] arrOfInt2 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            List<char> chars = arrOfInt2
                                    .Where(i => 65 <= i && i <= 90)
                                    .Skip(arrOfInt1[0])
                                    .Take(arrOfInt1[1])
                                    .Select(i => (char)i)
                                    .ToList();

            Console.WriteLine(string.Join("", chars));
        }
    }
}

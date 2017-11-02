using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int cols = 12 * n + 2;
            for (int i = 0; i < 2 * n; i++)
            {
                string underscores = new string('_', 4 * n - 2 * i);

                if((3 * underscores.Length + 2) == cols)
                {
                    Console.WriteLine(underscores + "." + underscores + "." + underscores);
                }
                else
                {
                    string middleAasteriks = new string('*', (cols - 3 * underscores.Length - 4) / 2);
                    Console.WriteLine(underscores + "." + middleAasteriks + "." + underscores + "." + middleAasteriks + "." + underscores);
                }
            }

            string asteriks = new string('*', (cols - 4) / 2);
            Console.WriteLine("." + asteriks + ".." + asteriks + ".");

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("." + new string('*', cols - 2) + ".");
            }

            Console.WriteLine(new string('.', 3 * n) + new string('*', cols - 2 * (3 * n)) + new string('.', 3 * n));

            // belt
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('_', 3 * n) + new string('o', cols - 2 * (3 * n)) + new string('_', 3 * n));
            }

            for(int i = 0; i < 3 * n; i++)
            {
                string underscores = new string('_', 3 * n - i);
                string middleAsteriks = new string('*', cols - 2 * underscores.Length - 2);

                Console.WriteLine(underscores + "." + middleAsteriks + "." + underscores);
            }

            Console.WriteLine(new string('.', cols));
        }

    }
}

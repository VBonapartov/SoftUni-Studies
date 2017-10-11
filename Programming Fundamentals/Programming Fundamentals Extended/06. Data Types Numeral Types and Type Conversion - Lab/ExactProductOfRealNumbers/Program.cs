using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactProductOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal exactProduct = 1m;
            for(int i = 1; i <= n; i++)
            {
                exactProduct *= decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine($"{exactProduct}");
        }
    }
}

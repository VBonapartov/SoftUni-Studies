using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> listDouble = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            List<double> result = listDouble;
            while (true)
            {
                bool isActive = false;
                for(int i = 0; i < result.Count - 1; i++)
                {
                    double sum = result[i] + result[i + 1];
                    if (result[i] == result[i + 1])
                    {
                        result.RemoveAt(i);
                        result.RemoveAt(i);
                        result.Insert(i, sum);
                        isActive = true;
                        break;
                    }
                }

                if (!isActive)
                    break;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

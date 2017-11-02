using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertrain
{
    class Program
    {
        static void Main(string[] args)
        {
            int locomotivePower = int.Parse(Console.ReadLine());

            List<int> wagons = new List<int>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("All ofboard!"))
            {
                int wagon = int.Parse(input);
                wagons.Add(wagon);

                int wagonsSum = wagons.Sum();
                if (wagonsSum > locomotivePower)
                {
                    int average = wagonsSum / wagons.Count();

                    List<int> res = wagons.Select(w => Math.Abs(w - average)).ToList();
                    int min = int.MaxValue;
                    int minIndex = 0;
                    for (int i = 0; i < res.Count; i++)
                    {
                        if (res[i] < min)
                        {
                            min = res[i];
                            minIndex = i;
                        }
                    }

                    wagons.RemoveAt(minIndex);
                }
            }

            wagons.Insert(0, locomotivePower);
            wagons.Reverse();
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}

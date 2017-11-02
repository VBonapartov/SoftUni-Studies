using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> arrInt = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string[] command = input.Split(' ');

                switch(command[0])
                {
                    case "swap":
                        Swap(arrInt, Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                        break;

                    case "multiply":
                        Multiply(arrInt, Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                        break;

                    case "decrease":
                        arrInt = Decrease(arrInt);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", arrInt));
        }

        private static void Swap(List<long> arrInt, int index1, int index2)
        {
            long valueAtIndex1 = arrInt[index1];
            arrInt[index1] = arrInt[index2];
            arrInt[index2] = valueAtIndex1;
        }

        private static void Multiply(List<long> arrInt, int index1, int index2)
        {
            arrInt[index1]  *= arrInt[index2];
        }

        private static List<long> Decrease(List<long> arrInt)
        {
            return arrInt.Select(i => --i).ToList();
        }
    }
}

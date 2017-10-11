using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrString = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            string[] resultArray = arrString;
            for(int i = 1; i <= n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch(command[0])
                {
                    case "Distinct":
                        resultArray = Distinct(resultArray);
                        break;
                    case "Reverse":
                        resultArray = Reverse(resultArray);
                        break;
                    case "Replace":
                        resultArray = Replace(resultArray, Convert.ToInt32(command[1]), command[2]);
                        break;
                }
            }

            PrintArray(resultArray);
        }

        static private string[] Distinct(string[] array)
        {
            string[] resultArray = array.Distinct().ToArray();
            return resultArray;
        }

        static private string[] Reverse(string[] array)
        {
            string[] resultArray = array.Reverse().ToArray();
            return resultArray;
        }

        static private string[] Replace(string[] array, int index, string item)
        {
            string[] resultArray = array;
            resultArray[index] = item;
            return resultArray;
        }

        static private void PrintArray(string[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}

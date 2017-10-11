using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrString = Console.ReadLine().Split(' ');

            string[] resultArray = arrString;
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("END"))
            {
                string[] command = input.Split(' ');

                switch (command[0])
                {
                    case "Distinct":
                        resultArray = Distinct(resultArray);
                        break;
                    case "Reverse":
                        resultArray = Reverse(resultArray);
                        break;
                    case "Replace":
                        int index = Convert.ToInt32(command[1]);
                        if (index < 0 || index >= resultArray.Length)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            resultArray = Replace(resultArray, index, command[2]);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
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

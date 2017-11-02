using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] result = arr;
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string[] commandArgs = input.Split(' ');
                string command = commandArgs[0];

                switch(command)
                {
                    case "exchange":
                        result = Exchange(result, Convert.ToInt32(commandArgs[1]));
                        break;

                    case "max":
                        Max(result, commandArgs[1]);
                        break;

                    case "min":
                        Min(result, commandArgs[1]);
                        break;

                    case "first":
                        First(result, Convert.ToInt32(commandArgs[1]), commandArgs[2]);
                        break;

                    case "last":
                        Last(result, Convert.ToInt32(commandArgs[1]), commandArgs[2]);
                        break;
                }
            }

            PrintResult(result);
        }

        private static int[] Exchange(int[] array, int index)
        {
            if(0 > index || index >= array.Length)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            int[] result = new int[array.Length];

            array.Where((i, idx) => idx > index).ToArray().CopyTo(result, 0);
            array.Where((i, idx) => idx <= index).ToArray().CopyTo(result, array.Length - index - 1);

            return result;
        }

        private static void Max(int[] array, string elementType)
        {
            int index = -1;
            if(elementType.Equals("odd"))
            {
                int prev = int.MinValue;
                for(int i = 0; i < array.Length; i++)
                {
                    if(array[i] % 2 != 0 && array[i] >= prev)
                    {
                        prev = array[i];
                        index = i;
                    }
                }
            }
            else if(elementType.Equals("even"))
            {
                int prev = int.MinValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= prev)
                    {
                        prev = array[i];
                        index = i;
                    }
                }
            }

            if(index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }           
        }

        private static void Min(int[] array, string elementType)
        {
            int index = -1;
            if (elementType.Equals("odd"))
            {
                int prev = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] <= prev)
                    {
                        prev = array[i];
                        index = i;
                    }
                }
            }
            else if (elementType.Equals("even"))
            {
                int prev = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= prev)
                    {
                        prev = array[i];
                        index = i;
                    }
                }
            }

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void First(int[] array, int count, string elementType)
        {
            if(count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> result = new List<int>();
            if (elementType.Equals("odd"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (result.Count >= count)
                        break;

                    if (array[i] % 2 != 0)
                        result.Add(array[i]);                    
                }
            }
            else if (elementType.Equals("even"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (result.Count >= count)
                        break;

                    if (array[i] % 2 == 0)
                        result.Add(array[i]);
                }
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static void Last(int[] array, int count, string elementType)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> result = new List<int>();
            if (elementType.Equals("odd"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                        result.Add(array[i]);

                    if (result.Count > count)
                        result.RemoveAt(0);
                }
            }
            else if (elementType.Equals("even"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                        result.Add(array[i]);

                    if (result.Count > count)
                        result.RemoveAt(0);
                }
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static void PrintResult(int[] result)
        {
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}

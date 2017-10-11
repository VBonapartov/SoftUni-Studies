using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizableArray
{
    class Program
    {
        static int totalElementsInArray = 0;

        static void Main(string[] args)
        {
            int[] arrInt = new int[4];

            int[] result = arrInt;
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("end"))
            {
                string[] command = input.Split(' ');
                switch (command[0])
                {
                    case "push":
                        result = Push(result, Convert.ToInt32(command[1]));
                        break;
                    case "pop":
                        result = Pop(result);
                        break;
                    case "removeAt":
                        result = RemoveAt(result, Convert.ToInt32(command[1]));
                        break;
                    case "clear":
                        Clear(result);
                        break;
                }
            }

            PrintResultArray(result);
        }

        static private int[] Push(int[] array, int number)
        {
            if (totalElementsInArray < array.GetLength(0))
            {
                array[totalElementsInArray++] = number;
                return array;
            }
            else
            {
                int[] newArray = new int[2 * array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    newArray[i] = array[i];
                }

                newArray[totalElementsInArray++] = number; ;
                return newArray;
            }
        }

        static private int[] Pop(int[] array)
        {
            int[] newArray = new int[array.GetLength(0)];
            for (int i = 0; i < totalElementsInArray - 1; i++)
            {
                newArray[i] = array[i];
            }

            totalElementsInArray--;
            return newArray;
        }

        static private int[] RemoveAt(int[] array, int position)
        {
            int[] newArray = new int[array.GetLength(0)];
            int p = 0;
            for (int i = 0; i < totalElementsInArray; i++)
            {
                if (i != position)
                {
                    newArray[p++] = array[i];
                }
            }

            totalElementsInArray--;
            return newArray;
        }

        static private void Clear(int[] array)
        {
            array = new int[array.GetLength(0)];
            totalElementsInArray = 0;
        }

        static private void PrintResultArray(int[] array)
        {
            if (totalElementsInArray > 0)
            {
                int[] newArray = new int[totalElementsInArray];
                for (int i = 0; i < totalElementsInArray; i++)
                {
                    newArray[i] = array[i];
                }

                Console.WriteLine(string.Join(" ", newArray));
            }
            else
            {
                Console.WriteLine("empty array");
            }
        }
    }
}

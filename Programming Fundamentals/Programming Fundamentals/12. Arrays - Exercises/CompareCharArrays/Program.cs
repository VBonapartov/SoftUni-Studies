using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arrChar1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arrChar2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            bool isPrint = false;
            int minArrayLength = Math.Min(arrChar1.Length, arrChar2.Length);
            for(int i = 0; i < minArrayLength; i++)
            {
                if(arrChar1.Length > arrChar2.Length)
                {
                    if(arrChar1[i] > arrChar2[i])
                    {
                        PrintArray(arrChar1);
                        PrintArray(arrChar2);
                        isPrint = true;
                    }
                    else if (arrChar1[i] < arrChar2[i])
                    {
                        PrintArray(arrChar2);
                        PrintArray(arrChar1);
                        isPrint = true;
                    }

                    break;
                }
                else 
                {
                    if (arrChar1[i] > arrChar2[i])
                    {
                        PrintArray(arrChar2);
                        PrintArray(arrChar1);
                        isPrint = true;
                    }
                    else if (arrChar1[i] < arrChar2[i])
                    {
                        PrintArray(arrChar1);
                        PrintArray(arrChar2);
                        isPrint = true;
                    }
                    
                    break;
                }
            }

            if(!isPrint)
            {
                if (arrChar1.Length > arrChar2.Length)
                {
                    PrintArray(arrChar2);
                    PrintArray(arrChar1);
                }
                else
                {
                    PrintArray(arrChar1);
                    PrintArray(arrChar2);
                }
            }
        }

        static private void PrintArray(char[] array)
        {
            foreach (char ch in array)
                Console.Write(ch);

            Console.WriteLine();
        }
    }
}

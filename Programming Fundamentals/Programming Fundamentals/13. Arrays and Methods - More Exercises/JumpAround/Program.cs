using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int nextIndex = 0;
            int nextStep = arrInt[nextIndex];

            int sum = nextStep;

            while (true)
            {                
                if (MoveRight(arrInt, nextIndex, nextStep, out nextIndex, out nextStep))
                {
                    sum += nextStep;
                    continue;
                }
                                                
                if (MoveLeft(arrInt, nextIndex, nextStep, out nextIndex, out nextStep))
                {
                    sum += nextStep;
                    continue;
                }

                break;
            }

            Console.WriteLine(sum);
        }

        static private bool MoveRight(int[] array, int currentIndex, int step, out int nextIndex, out int nextStep)
        {
            nextIndex = currentIndex;
            nextStep = step;

            int lengthArray = array.Length;
            if ((currentIndex + step) < lengthArray)
            {
                nextIndex = currentIndex + step;
                nextStep = array[nextIndex];
                return true;                
            }
            else
            {
                return false;
            }
        }

        static private bool MoveLeft(int[] array, int currentIndex, int step, out int nextIndex, out int nextStep)
        {
            nextIndex = currentIndex;
            nextStep = step;

            if ((currentIndex - step) >= 0)
            {
                nextIndex = currentIndex - step;
                nextStep = array[nextIndex];
                return true;
            }
            else
            {                
                return false;
            }
        }
    }
}

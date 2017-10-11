using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extremums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            List<int> result = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                switch (command)
                {
                    case "Min":
                        result = nums.Select(x => GetMinNumberByRotation(x)).ToList();
                        break;

                    case "Max":
                        result = nums.Select(x => GetMaxNumberByRotation(x)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(result.Sum());
        }

        static private int GetMinNumberByRotation(int number)
        {
            int numLen = number.ToString().Length;

            int minNumber = number;
            for (int i = 0; i < numLen; i++)
            {
                minNumber = Math.Min(minNumber, RotateNumber(number, i));
            }

            return minNumber;
        }

        static private int GetMaxNumberByRotation(int number)
        {
            int numLen = number.ToString().Length;

            int maxNumber = number;
            for (int i = 0; i < numLen; i++)
            {                
                maxNumber = Math.Max(maxNumber, RotateNumber(number, i));
            }

            return maxNumber;
        }

        static private int RotateNumber(int number, int times)
        {
            List<char> numberToString = number.ToString().ToCharArray().ToList();

            for (int p = 0; p < times; p++)
            {
                char currentDigit = numberToString[0];
                numberToString.RemoveAt(0);
                numberToString.Add(currentDigit);
            }

            int num = 0;
            bool isNumber = int.TryParse(new string(numberToString.ToArray()), out num);

            return num;
        }
    }
}

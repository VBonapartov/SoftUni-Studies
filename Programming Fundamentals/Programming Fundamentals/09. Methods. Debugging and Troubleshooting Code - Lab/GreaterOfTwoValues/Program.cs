using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string value1 = Console.ReadLine();
            string value2 = Console.ReadLine();

            string result = string.Empty;
            switch (type)
            {
                case "int":
                    result = GetMax(Convert.ToInt32(value1), Convert.ToInt32(value2)).ToString();
                    break;
                case "char":
                    result = GetMax(value1[0], value2[0]).ToString();
                    break;
                case "string":
                    result = GetMax(value1, value2);
                    break;
            }

            Console.WriteLine(result);
        }

        static private int GetMax(int first, int second)
        {
            int result = Math.Max(first, second);
            return result;
        }

        static private char GetMax(char first, char second)
        {
            char result = (first > second) ? first : second;
            return result;
        }

        static private string GetMax(string first, string second)
        {
            string result = second;

            if (first.CompareTo(second) >= 0)
            {
                result = first;
            }

            return result;
        }

    }
}

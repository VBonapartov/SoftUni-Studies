namespace _01.ArrangeIntegers
{
    using System;

    class Program
    {
        private static string[] digitsAsString = new string[10] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        static void Main(string[] args)
        {
            string[] inputArray = ReadInputArray();
            string[] numberNames = ConvertInputArray(inputArray);

            SortNumberNames(numberNames);

            string[] numbers = ConvertNumberNamesToNumbers(numberNames);
            PrintResult(numbers);            
        }

        private static string[] ReadInputArray()
        {
            return Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string[] ConvertInputArray(string[] inputArray)
        {
            string[] stringArray = new string[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                string numberAsString = string.Empty;

                foreach (char ch in inputArray[i])
                {
                    numberAsString += digitsAsString[int.Parse(ch.ToString())] + "-";
                }

                stringArray[i] = numberAsString.Substring(0, numberAsString.Length - 1);
            }

            return stringArray;
        }

        private static void SortNumberNames(string[] numberNames)
        {
            Func<string, string, int> comparator = (string x, string y) =>
                 (x.StartsWith(y)) ? 1 :
                 (y.StartsWith(x)) ? -1 :
                 x.CompareTo(y);

            Array.Sort(numberNames, new Comparison<string>(comparator));
        }

        private static string[] ConvertNumberNamesToNumbers(string[] numberNames)
        {
            string[] result = new string[numberNames.Length];

            for (int i = 0; i < numberNames.Length; i++)
            {
                string[] strNum = numberNames[i].Split('-');

                foreach (string num in strNum)
                {
                    result[i] += Array.IndexOf(digitsAsString, num).ToString();
                }
            }

            return result;
        }

        private static void PrintResult(string[] numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

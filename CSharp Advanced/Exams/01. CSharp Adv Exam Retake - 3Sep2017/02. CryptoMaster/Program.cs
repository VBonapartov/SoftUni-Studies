namespace _02.CryptoMaster
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {         
            int[] inputNums = Console.ReadLine()
                                        .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();   

            Console.WriteLine(GetLongestSequence(inputNums));
        }

        private static int GetLongestSequence(int[] inputNums)
        {
            int maxSequenceLength = 0;

            for (int step = 1; step < inputNums.Length; step++)
            {
                for (int element = 0; element < inputNums.Length; element++)
                {
                    int currentLength = 1;

                    int currentElement = element;
                    int nextElement = (currentElement + step) % inputNums.Length;

                    while (inputNums[nextElement] > inputNums[currentElement])
                    {
                        currentLength++;

                        currentElement = nextElement;
                        nextElement = (currentElement + step) % inputNums.Length; ;
                    }

                    if (currentLength > maxSequenceLength)
                    {
                        maxSequenceLength = currentLength;
                    }
                }
            }

            return maxSequenceLength;
        }
    }
}

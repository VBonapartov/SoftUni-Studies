using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramidic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputStrings = ReadInput();
            List<string> pyramids = GetIncreacingSequence(inputStrings);
            PrintPyramid(pyramids);
        }

        private static List<string> ReadInput()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<string> inputStrings = new List<string>();
            for (int i = 0; i < numberOfLines; i++)
                inputStrings.Add(Console.ReadLine());

            return inputStrings;
        }

        private static List<string> GetIncreacingSequence(List<string> inputStrings)
        {
            int index = 0;
            int newStr = 1;
            List<string> pyramids = new List<string>();

            foreach (string inputStr in inputStrings)
            {
                foreach (char ch in inputStr)
                {
                    foreach (string sequence in inputStrings.Skip(index + 1))
                    {
                        string str = new string(ch, newStr + 2);

                        if (sequence.Contains(str))
                        {
                            if (sequence == inputStrings[inputStrings.Count - 1])
                            {
                                pyramids.Add(str);
                            }
                            newStr += 2;
                        }
                        else
                        {
                            pyramids.Add(new string(ch, newStr));
                            break;
                        }
                    }

                    newStr = 1;
                }

                index++;
            }

            return pyramids;
        }

        private static void PrintPyramid(List<string> pyramids)
        {
            string biggestPyramid = pyramids.OrderByDescending(x => x.Length).First();           
            for (int i = 1; i <= biggestPyramid.Length; i += 2)
            {
                Console.WriteLine(new string(biggestPyramid[0], i));
            }
        }
    }
}

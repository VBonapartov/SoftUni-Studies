using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunctuationFinder
{
    class Program
    {
        static char[] punctuationMarks = new char[] { '.', ',', '!', '?', ':' };

        static void Main(string[] args)
        {
            string fileName = "text.txt";
            List<char> punctuationMarksOutput = ReadPunctuationMarksFromFile(fileName);
            PrintResult(punctuationMarksOutput);
        }

        private static List<char> ReadPunctuationMarksFromFile(string fileName)
        {
            List<char> result = new List<char>();

            if (File.Exists(fileName))
            {
                string line = string.Empty;
                using (StreamReader reader = File.OpenText(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        result.AddRange(FindPunctuationMarks(line));
                    }
                }
            }

            return result;
        }

        private static List<char> FindPunctuationMarks(string line)
        {
            List<char> result = line.Where(c => punctuationMarks.Contains(c)).ToList();
            return result;
        }

        private static void PrintResult(List<char> punctuationMarksOutput)
        {
            Console.WriteLine(string.Join(", ", punctuationMarksOutput));
        }
    }
}

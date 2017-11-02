using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFile
{
    class Program
    {
        static char[] punctuationMarks = new char[] { '.', ',', '!', '?', ':' };

        static void Main(string[] args)
        {
            string inputFileName = "text.txt";
            string outputFileName = "OutputText.txt";

            StringBuilder text = ReadFileWithoutPunctuationMarks(inputFileName);
            WriteToFile(outputFileName, text);
        }

        private static StringBuilder ReadFileWithoutPunctuationMarks(string fileName)
        {
            StringBuilder resultText = new StringBuilder();

            if (File.Exists(fileName))
            {
                string line = string.Empty;
                using (StreamReader reader = File.OpenText(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (resultText.Length > 0)
                            resultText.Append(Environment.NewLine);

                        resultText.Append(RemovePunctuationMarksFromText(line));
                    }
                }
            }

            return resultText;
        }

        private static string RemovePunctuationMarksFromText(string text)
        {
            return new string(text.Where(c => !punctuationMarks.Contains(c)).ToArray());
        }

        private static void WriteToFile(string fileName, StringBuilder text)
        {
            using (FileStream target = File.Open(fileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(target))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}
